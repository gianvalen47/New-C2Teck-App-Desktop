using System.Data;
using System.Net;
using System.Net.Security;
using System.Reflection;
using System.Runtime.Serialization;
using System.Security.Principal;
using System.ServiceModel;
using Microsoft.AspNetCore.Mvc;

namespace sigecoom_wcf_adapter.Controllers
{
    [ServiceContract(Name = "ISeguridad", Namespace = "http://tempuri.org/")]
    public interface ISeguridadService
    {
        [OperationContract(Action = "http://tempuri.org/ISeguridad/ValidarAccesoUsuario", ReplyAction = "http://tempuri.org/ISeguridad/ValidarAccesoUsuarioResponse")]
        int ValidarAccesoUsuario(string pCodUsu, string pClave, int pIdSistema);

        [OperationContract(Action = "http://tempuri.org/ISeguridad/MostrarMultiEmpresa", ReplyAction = "http://tempuri.org/ISeguridad/MostrarMultiEmpresaResponse")]
        DataSet MostrarMultiEmpresa(string pCodUsu);

        [OperationContract(Action = "http://tempuri.org/ISeguridad/AccesoMultiEmpresa", ReplyAction = "http://tempuri.org/ISeguridad/AccesoMultiEmpresaResponse")]
        bool AccesoMultiEmpresa(string pCodUsu);

        [OperationContract(Action = "http://tempuri.org/ISeguridad/FiltrarUsuarios", ReplyAction = "http://tempuri.org/ISeguridad/FiltrarUsuariosResponse")]
        DataSet FiltrarUsuarios(string pCodUsu, string pApeNom, string pCodArea, bool pVigente);
    }

    [ApiController]
    [Route("api/v1")]
    public class SeguridadController : ControllerBase
    {
        private readonly string _serviceAddress;
        private readonly string _companyCode;
        private readonly string? _domain;
        private readonly string? _username;
        private readonly string? _password;

        public SeguridadController(IConfiguration configuration)
        {
            _serviceAddress = configuration.GetValue<string>("Sigecoom:SeguridadServiceBaseUrl")
                ?? Environment.GetEnvironmentVariable("SIGECOM_SEGURIDAD_SERVICE_URL")
                ?? "net.tcp://192.168.10.252/ServicioBLL/Seguridad/";

            _companyCode = configuration.GetValue<string>("Sigecoom:CompanyCode")
                ?? Environment.GetEnvironmentVariable("SIGECOM_COD_EMP")
                ?? "01";

            _domain = configuration.GetValue<string>("Sigecoom:Domain")
                ?? Environment.GetEnvironmentVariable("SIGECOM_DOMAIN");
            _username = configuration.GetValue<string>("Sigecoom:Username")
                ?? Environment.GetEnvironmentVariable("SIGECOM_USERNAME");
            _password = configuration.GetValue<string>("Sigecoom:Password")
                ?? Environment.GetEnvironmentVariable("SIGECOM_PASSWORD");
        }

        [HttpGet("auth/validate")]
        public IActionResult Validate([FromQuery] string? username, [FromQuery] string? password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return BadRequest(new { error = "username and password required" });
            }

            // Local fallback is intentionally disabled by default. The real source of truth
            // must be the legacy SIGECOM adapter / WCF, not a fake in-repo JSON file.
            var localFallbackEnabled = Environment.GetEnvironmentVariable("SIGECOM_ENABLE_LOCAL_FALLBACK") ?? "";
            if (localFallbackEnabled.Equals("1", StringComparison.OrdinalIgnoreCase)
                || localFallbackEnabled.Equals("true", StringComparison.OrdinalIgnoreCase)
                || localFallbackEnabled.Equals("yes", StringComparison.OrdinalIgnoreCase))
            {
                var localUsersPath = Environment.GetEnvironmentVariable("SIGECOM_LOCAL_USERS_FILE");
                if (!string.IsNullOrWhiteSpace(localUsersPath) && System.IO.File.Exists(localUsersPath))
                {
                    try
                    {
                        var txt = System.IO.File.ReadAllText(localUsersPath);
                        var opts = new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                        var entries = System.Text.Json.JsonSerializer.Deserialize<System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, object>>>(txt, opts);
                        if (entries != null)
                        {
                            foreach (var e in entries)
                            {
                                var u = e.ContainsKey("username") ? (e["username"]?.ToString() ?? "") : "";
                                var p = e.ContainsKey("password") ? (e["password"]?.ToString() ?? "") : "";
                                if (string.Equals(u, username, System.StringComparison.OrdinalIgnoreCase) && p == password)
                                {
                                    var perfil = e.ContainsKey("perfil") ? (e["perfil"]?.ToString() ?? "Usuario") : "Usuario";
                                    var empresasVal = e.ContainsKey("empresas") ? e["empresas"] : null;
                                    return Ok(new { username = username, perfil = perfil, empresas = empresasVal, source = "local" });
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Local users parse error: {ex.Message}");
                    }
                }
            }

            try
            {
                var channel = CreateClient();
                var result = channel.ValidarAccesoUsuario(username, password, 1);
                if (result <= 0)
                {
                    return Unauthorized(new { ok = false });
                }

                // Try to obtain assigned companies
                DataSet ds = null;
                try
                {
                    ds = channel.MostrarMultiEmpresa(username);
                }
                catch { }

                var empresas = ParseEmpresas(ds);

                return Ok(new { username = username, perfil = "Usuario", empresas = empresas, source = "wcf" });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"SeguridadService error: {ex.Message}");
                Console.WriteLine($"Inner exception: {ex.InnerException?.Message}");
                return Problem(title: "SIGECOM WCF error", detail: ex.InnerException?.Message ?? ex.Message, statusCode: StatusCodes.Status503ServiceUnavailable);
            }
        }

        [HttpGet("auth/empresas")]
        public IActionResult Empresas([FromQuery] string? username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return BadRequest(new { error = "username required" });

            try
            {
                var channel = CreateClient();
                var ds = channel.MostrarMultiEmpresa(username);
                var empresas = ParseEmpresas(ds);
                return Ok(empresas);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"SeguridadService error: {ex.Message}");
                return Problem(title: "SIGECOM WCF error", detail: ex.Message, statusCode: StatusCodes.Status503ServiceUnavailable);
            }
        }

        [HttpGet("auth/users")]
        public IActionResult Users([FromQuery] bool? vigente)
        {
            try
            {
                var channel = CreateClient();
            var vig = vigente ?? true;
            var ds = channel.FiltrarUsuarios("", "", "", vig);
                var list = new List<object>();

                if (ds != null && ds.Tables.Count > 0)
                {
                    var table = ds.Tables[0];
                    foreach (DataRow row in table.Rows)
                    {
                        string? username = null;
                        if (table.Columns.Contains("CodUsu")) username = row["CodUsu"]?.ToString();
                        else if (table.Columns.Contains("Usuario")) username = row["Usuario"]?.ToString();
                        else if (table.Columns.Contains("Codigo")) username = row["Codigo"]?.ToString();

                        string? fullname = null;
                        if (table.Columns.Contains("ApeNom")) fullname = row["ApeNom"]?.ToString();
                        else if (table.Columns.Contains("Nombres")) fullname = row["Nombres"]?.ToString();
                        else if (table.Columns.Contains("Nombre")) fullname = row["Nombre"]?.ToString();
                        else
                        {
                            var parts = new List<string>();
                            if (table.Columns.Contains("ApePat")) parts.Add(row["ApePat"]?.ToString() ?? "");
                            if (table.Columns.Contains("ApeMat")) parts.Add(row["ApeMat"]?.ToString() ?? "");
                            if (table.Columns.Contains("Nombres")) parts.Add(row["Nombres"]?.ToString() ?? "");
                            fullname = string.Join(" ", parts.Where(s => !string.IsNullOrWhiteSpace(s)));
                        }

                        if (!string.IsNullOrWhiteSpace(username))
                        {
                            list.Add(new { username = username, fullName = fullname });
                        }
                    }
                }

                return Ok(list);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"SeguridadService error (users): {ex.Message}");
                return Problem(title: "SIGECOM WCF error", detail: ex.Message, statusCode: StatusCodes.Status503ServiceUnavailable);
            }
        }

        private ISeguridadService CreateClient()
        {
            var binding = new NetTcpBinding(SecurityMode.Transport)
            {
                CloseTimeout = TimeSpan.FromMinutes(1),
                OpenTimeout = TimeSpan.FromMinutes(1),
                ReceiveTimeout = TimeSpan.FromMinutes(10),
                SendTimeout = TimeSpan.FromMinutes(1),
                MaxBufferPoolSize = 2147483641,
                MaxBufferSize = 2147483641,
                MaxReceivedMessageSize = 65536,
                Security = new NetTcpSecurity
                {
                    Mode = SecurityMode.Transport,
                    Transport = new TcpTransportSecurity
                    {
                        ClientCredentialType = TcpClientCredentialType.Windows,
                        ProtectionLevel = ProtectionLevel.EncryptAndSign,
                    }
                }
            };

            var factory = new ChannelFactory<ISeguridadService>(binding, new EndpointAddress(_serviceAddress));

            if (!string.IsNullOrWhiteSpace(_username) && !string.IsNullOrWhiteSpace(_password))
            {
                factory.Credentials.Windows.ClientCredential = new NetworkCredential(
                    _username,
                    _password,
                    string.IsNullOrWhiteSpace(_domain) ? Environment.UserDomainName : _domain);
                factory.Credentials.Windows.AllowedImpersonationLevel = TokenImpersonationLevel.Impersonation;
            }
            else
            {
                factory.Credentials.Windows.ClientCredential = CredentialCache.DefaultNetworkCredentials;
                factory.Credentials.Windows.AllowedImpersonationLevel = TokenImpersonationLevel.Impersonation;
            }

            return factory.CreateChannel();
        }

        private static IEnumerable<object> ParseEmpresas(DataSet? dataset)
        {
            var list = new List<object>();
            if (dataset == null || dataset.Tables.Count == 0) return list;

            var table = dataset.Tables[0];
            foreach (DataRow row in table.Rows)
            {
                var codigo = row.Table.Columns.Contains("CodEmp") ? row["CodEmp"]?.ToString() : row.Table.Columns.Contains("Codigo") ? row["Codigo"]?.ToString() : null;
                var nombre = row.Table.Columns.Contains("Razon") ? row["Razon"]?.ToString() : row.Table.Columns.Contains("DesEmp") ? row["DesEmp"]?.ToString() : row.Table.Columns.Contains("Nombre") ? row["Nombre"]?.ToString() : codigo;
                var ruc = row.Table.Columns.Contains("Ruc") ? row["Ruc"]?.ToString() : row.Table.Columns.Contains("RucEmp") ? row["RucEmp"]?.ToString() : null;
                if (codigo != null)
                {
                    list.Add(new { codigo = codigo, nombre = nombre ?? codigo, ruc = ruc });
                }
            }

            return list;
        }
    }
}
