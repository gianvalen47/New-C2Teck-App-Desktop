using System.Data;
using System.Net;
using System.Net.Security;
using System.Reflection;
using System.Runtime.Serialization;
using System.Security.Principal;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
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
        
        [OperationContract(Action = "http://tempuri.org/ISeguridad/MostrarUsuarioSistema", ReplyAction = "http://tempuri.org/ISeguridad/MostrarUsuarioSistemaResponse")]
        DataSet MostrarUsuarioSistema(string pCodUsu);

        [OperationContract(Action = "http://tempuri.org/ISeguridad/MostrarPermisos", ReplyAction = "http://tempuri.org/ISeguridad/MostrarPermisosResponse")]
        DataSet MostrarPermisos(string pCodUsu);
        [OperationContract(Action = "http://tempuri.org/ISeguridad/MostrarPerfiles", ReplyAction = "http://tempuri.org/ISeguridad/MostrarPerfilesResponse")]
        DataSet MostrarPerfiles();

        [OperationContract(Action = "http://tempuri.org/ISeguridad/MostrarPerfilPorCodigo", ReplyAction = "http://tempuri.org/ISeguridad/MostrarPerfilPorCodigoResponse")]
        DataSet MostrarPerfilPorCodigo(string pCodPerfil);
        [OperationContract(Action = "http://tempuri.org/ISeguridad/MostrarPerfilOpciones", ReplyAction = "http://tempuri.org/ISeguridad/MostrarPerfilOpcionesResponse")]
        DataSet MostrarPerfilOpciones(string pCodPerfil, int pIdMenu, string pCodEmp);
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

                // Try to obtain a real perfil for the user by querying the user list
                string? perfil = null;
                try
                {
                    var dsUsers = channel.FiltrarUsuarios(username, "", "", true);
                    if (dsUsers != null && dsUsers.Tables.Count > 0)
                    {
                        var t = dsUsers.Tables[0];
                        if (t.Rows.Count > 0)
                        {
                            var r = t.Rows[0];
                            // common column names for perfil/role
                            if (t.Columns.Contains("Perfil")) perfil = r["Perfil"]?.ToString();
                            else if (t.Columns.Contains("TipoUsuario")) perfil = r["TipoUsuario"]?.ToString();
                            else if (t.Columns.Contains("Tipo") ) perfil = r["Tipo"]?.ToString();
                            else if (t.Columns.Contains("Rol")) perfil = r["Rol"]?.ToString();
                            else if (t.Columns.Contains("DescripcionPerfil")) perfil = r["DescripcionPerfil"]?.ToString();
                            else if (t.Columns.Contains("NombrePerfil")) perfil = r["NombrePerfil"]?.ToString();
                        }
                    }
                }
                catch { }

                return Ok(new { username = username, perfil = perfil, empresas = empresas, source = "wcf" });
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
                            // try to extract perfil if available in the row
                            string? perfil = null;
                            if (table.Columns.Contains("Perfil")) perfil = row["Perfil"]?.ToString();
                            else if (table.Columns.Contains("TipoUsuario")) perfil = row["TipoUsuario"]?.ToString();
                            else if (table.Columns.Contains("Tipo")) perfil = row["Tipo"]?.ToString();
                            else if (table.Columns.Contains("Rol")) perfil = row["Rol"]?.ToString();

                            list.Add(new { username = username, fullName = fullname, perfil = perfil });
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

        [HttpGet("auth/userinfo")]
        public IActionResult UserInfo([FromQuery] string? username)
        {
            if (string.IsNullOrWhiteSpace(username)) return BadRequest(new { error = "username required" });

            try
            {
                var channel = CreateClient();
                var ds = channel.MostrarUsuarioSistema(username);
                var rows = DataSetToObjects(ds);
                return Ok(new { username = username, rows = rows, source = "MostrarUsuarioSistema" });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"SeguridadService error (userinfo): {ex.Message}");
                return Problem(title: "SIGECOM WCF error", detail: ex.Message, statusCode: StatusCodes.Status503ServiceUnavailable);
            }
        }

        [HttpGet("auth/userperms")]
        public IActionResult UserPerms([FromQuery] string? username)
        {
            if (string.IsNullOrWhiteSpace(username)) return BadRequest(new { error = "username required" });

            try
            {
                var channel = CreateClient();
                var ds = channel.MostrarPermisos(username);
                // Some MostrarPermisos overloads return all perms or require username; attempt to filter client-side if username provided
                var rows = DataSetToObjects(ds);
                var filtered = rows;
                if (!string.IsNullOrWhiteSpace(username))
                {
                    filtered = rows.Where(r => {
                        try
                        {
                            var d = r as System.Collections.Generic.IDictionary<string, object>;
                            if (d == null) return false;
                            foreach (var k in new[] { "CodUsu", "Usuario", "CodUsuPermiso", "UsuarioPermiso", "CodUsuario" })
                            {
                                if (d.ContainsKey(k) && d[k] != null && d[k].ToString().Equals(username, StringComparison.OrdinalIgnoreCase)) return true;
                            }
                        }
                        catch { }
                        return false;
                    }).ToList();
                }

                return Ok(new { username = username, perms = filtered, source = "MostrarPermisos" });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"SeguridadService error (userperms): {ex.Message}");
                return Problem(title: "SIGECOM WCF error", detail: ex.Message, statusCode: StatusCodes.Status503ServiceUnavailable);
            }
        }

        [HttpGet("auth/perfiles")]
        public IActionResult Perfiles()
        {
            try
            {
                var channel = CreateClient();
                var ds = channel.MostrarPerfiles();
                var rows = DataSetToObjects(ds);

                // map common profile fields to codigo/nombre
                var list = rows.Select(r =>
                {
                    try
                    {
                        var d = r as System.Collections.Generic.IDictionary<string, object>;
                        string? codigo = null;
                        string? nombre = null;
                        if (d != null)
                        {
                            foreach (var k in new[] { "Codigo", "CodPerfil", "CodigoPerfil", "IdPerfil", "CodigoPerfil" }) if (d.ContainsKey(k) && codigo == null) codigo = d[k]?.ToString();
                            foreach (var k in new[] { "Nombre", "NombrePerfil", "Descripcion", "DescripcionPerfil", "NombrePerfil" }) if (d.ContainsKey(k) && nombre == null) nombre = d[k]?.ToString();
                        }
                        return new { codigo = codigo, nombre = nombre };
                    }
                    catch { return new { codigo = (string?)null, nombre = (string?)null }; }
                }).ToList();

                return Ok(list);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"SeguridadService error (perfiles): {ex.Message}");
                return Problem(title: "SIGECOM WCF error", detail: ex.Message, statusCode: StatusCodes.Status503ServiceUnavailable);
            }
        }

        [HttpGet("auth/perfil/check")]
        public IActionResult PerfilCheck([FromQuery] string? username, [FromQuery] string? perfil)
        {
            if (string.IsNullOrWhiteSpace(username) && string.IsNullOrWhiteSpace(perfil)) return BadRequest(new { error = "username or perfil required" });

            try
            {
                var channel = CreateClient();

                string? perfilCodigo = null;
                string? perfilNombre = null;

                // If username provided, try to read assigned perfil from FiltrarUsuarios or MostrarUsuarioSistema
                if (!string.IsNullOrWhiteSpace(username))
                {
                    try
                    {
                        var dsUsers = channel.FiltrarUsuarios(username, "", "", true);
                        if (dsUsers != null && dsUsers.Tables.Count > 0 && dsUsers.Tables[0].Rows.Count > 0)
                        {
                            var r = dsUsers.Tables[0].Rows[0];
                            if (dsUsers.Tables[0].Columns.Contains("CodPerfil")) perfilCodigo = r["CodPerfil"]?.ToString();
                            if (dsUsers.Tables[0].Columns.Contains("CodigoPerfil") && perfilCodigo == null) perfilCodigo = r["CodigoPerfil"]?.ToString();
                            if (dsUsers.Tables[0].Columns.Contains("Perfil") || dsUsers.Tables[0].Columns.Contains("NombrePerfil") || dsUsers.Tables[0].Columns.Contains("DescripcionPerfil"))
                            {
                                if (dsUsers.Tables[0].Columns.Contains("Perfil")) perfilNombre = r["Perfil"]?.ToString();
                                else if (dsUsers.Tables[0].Columns.Contains("NombrePerfil")) perfilNombre = r["NombrePerfil"]?.ToString();
                                else perfilNombre = r["DescripcionPerfil"]?.ToString();
                            }
                        }
                    }
                    catch { }

                    if (perfilCodigo == null && perfilNombre == null)
                    {
                        try
                        {
                            var dsInfo = channel.MostrarUsuarioSistema(username);
                            var rows = DataSetToObjects(dsInfo);
                            if (rows.Count > 0)
                            {
                                var d = rows[0] as System.Collections.Generic.IDictionary<string, object>;
                                if (d != null)
                                {
                                    foreach (var k in new[] { "CodPerfil", "CodigoPerfil", "IdPerfil" }) if (d.ContainsKey(k) && perfilCodigo == null) perfilCodigo = d[k]?.ToString();
                                    foreach (var k in new[] { "Perfil", "NombrePerfil", "DescripcionPerfil" }) if (d.ContainsKey(k) && perfilNombre == null) perfilNombre = d[k]?.ToString();
                                }
                            }
                        }
                        catch { }
                    }
                }

                // If perfil param provided, use it directly (could be code or name)
                if (!string.IsNullOrWhiteSpace(perfil))
                {
                    // detect if looks like a code (numeric or short) or a name
                    if (perfil.Length <= 4 && perfil.All(c => char.IsDigit(c) || c == '0')) perfilCodigo = perfil;
                    else
                    {
                        perfilNombre = perfil;
                        // try to find code by matching name in MostrarPerfiles
                        try
                        {
                            var dsAll = channel.MostrarPerfiles();
                            var rowsAll = DataSetToObjects(dsAll);
                            foreach (var r in rowsAll)
                            {
                                var d = r as System.Collections.Generic.IDictionary<string, object>;
                                if (d == null) continue;
                                string? nombre = null; string? codigo = null;
                                foreach (var k in new[] { "Nombre", "NombrePerfil", "Descripcion", "DescripcionPerfil" }) if (d.ContainsKey(k) && nombre == null) nombre = d[k]?.ToString();
                                foreach (var k in new[] { "Codigo", "CodPerfil", "CodigoPerfil", "IdPerfil" }) if (d.ContainsKey(k) && codigo == null) codigo = d[k]?.ToString();
                                if (!string.IsNullOrWhiteSpace(nombre) && nombre.Equals(perfil, StringComparison.OrdinalIgnoreCase)) { perfilCodigo = codigo; break; }
                            }
                        }
                        catch { }
                    }
                }

                // If we only have code, try to get the name
                if (perfilNombre == null && perfilCodigo != null)
                {
                    try
                    {
                        var dsP = channel.MostrarPerfilPorCodigo(perfilCodigo);
                        var rowsP = DataSetToObjects(dsP);
                        if (rowsP.Count > 0)
                        {
                            var d = rowsP[0] as System.Collections.Generic.IDictionary<string, object>;
                            if (d != null)
                            {
                                foreach (var k in new[] { "Nombre", "NombrePerfil", "Descripcion", "DescripcionPerfil" }) if (d.ContainsKey(k) && perfilNombre == null) perfilNombre = d[k]?.ToString();
                            }
                        }
                    }
                    catch { }
                }

                // Fallback: fetch all perfiles and try to match by code or name
                if (perfilCodigo == null && perfilNombre != null)
                {
                    try
                    {
                        var dsAll = channel.MostrarPerfiles();
                        var rowsAll = DataSetToObjects(dsAll);
                        foreach (var r in rowsAll)
                        {
                            var d = r as System.Collections.Generic.IDictionary<string, object>;
                            if (d == null) continue;
                            string? nombre = null; string? codigo = null;
                            foreach (var k in new[] { "Nombre", "NombrePerfil", "Descripcion", "DescripcionPerfil" }) if (d.ContainsKey(k) && nombre == null) nombre = d[k]?.ToString();
                            foreach (var k in new[] { "Codigo", "CodPerfil", "CodigoPerfil", "IdPerfil" }) if (d.ContainsKey(k) && codigo == null) codigo = d[k]?.ToString();
                            if (!string.IsNullOrWhiteSpace(nombre) && perfilNombre.Equals(nombre, StringComparison.OrdinalIgnoreCase)) { perfilCodigo = codigo; break; }
                        }
                    }
                    catch { }
                }

                // Determine admin or consultor
                bool isAdmin = false;
                bool isConsultor = false;

                if (!string.IsNullOrWhiteSpace(perfilCodigo) && perfilCodigo.TrimStart('0') == "1") isAdmin = true; // code 01
                if (!isAdmin && !string.IsNullOrWhiteSpace(perfilNombre))
                {
                    var low = perfilNombre.ToLowerInvariant();
                    if (low.Contains("admin") || low.Contains("administrador") || low.Contains("administration")) isAdmin = true;
                    if (low.Contains("consult" ) || low.Contains("consultor")) isConsultor = true;
                }

                var roleType = isAdmin ? "Administrador" : (isConsultor ? "Consultor" : "Otro");

                return Ok(new { username = username, perfilCodigo = perfilCodigo, perfilNombre = perfilNombre, isAdmin = isAdmin, isConsultor = isConsultor, roleType = roleType });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"SeguridadService error (perfil check): {ex.Message}");
                return Problem(title: "SIGECOM WCF error", detail: ex.Message, statusCode: StatusCodes.Status503ServiceUnavailable);
            }
        }

        [HttpGet("auth/users/infer")]
        public IActionResult InferUsersProfiles([FromQuery] bool? vigente)
        {
            try
            {
                var channel = CreateClient();
                var vig = vigente ?? true;

                // Load users
                var dsUsers = channel.FiltrarUsuarios("", "", "", vig);
                var users = new List<(string username, string fullName)>();
                if (dsUsers != null && dsUsers.Tables.Count > 0)
                {
                    var table = dsUsers.Tables[0];
                    foreach (DataRow row in table.Rows)
                    {
                        string? username = null;
                        string? fullname = null;
                        if (table.Columns.Contains("CodUsu")) username = row["CodUsu"]?.ToString();
                        else if (table.Columns.Contains("Usuario")) username = row["Usuario"]?.ToString();
                        else if (table.Columns.Contains("Codigo")) username = row["Codigo"]?.ToString();

                        if (table.Columns.Contains("ApeNom")) fullname = row["ApeNom"]?.ToString();
                        else if (table.Columns.Contains("Nombres")) fullname = row["Nombres"]?.ToString();

                        if (!string.IsNullOrWhiteSpace(username)) users.Add((username!, fullname ?? ""));
                    }
                }

                // Load profiles
                var perfilRows = DataSetToObjects(channel.MostrarPerfiles());
                var perfiles = new List<(string codigo, string nombre)>();
                foreach (var r in perfilRows)
                {
                    var d = r as System.Collections.Generic.IDictionary<string, object>;
                    if (d == null) continue;
                    string? codigo = null; string? nombre = null;
                    foreach (var k in new[] { "Codigo", "CodPerfil", "CodigoPerfil", "IdPerfil" }) if (d.ContainsKey(k) && codigo == null) codigo = d[k]?.ToString();
                    foreach (var k in new[] { "Nombre", "NombrePerfil", "Descripcion", "DescripcionPerfil" }) if (d.ContainsKey(k) && nombre == null) nombre = d[k]?.ToString();
                    if (!string.IsNullOrWhiteSpace(codigo)) perfiles.Add((codigo!, nombre ?? ""));
                }

                // Build profile->permsets map by iterating several menus and normalizing names
                var perfilPerms = new Dictionary<string, HashSet<string>>();
                foreach (var p in perfiles)
                {
                    var set = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                    try
                    {
                        // iterate menu ids to collect more options (0..10)
                        for (int menu = 0; menu <= 10; menu++)
                        {
                            try
                            {
                                var dsP = channel.MostrarPerfilOpciones(p.codigo, menu, _companyCode);
                                var rowsP = DataSetToObjects(dsP);
                                foreach (var rp in rowsP)
                                {
                                    var d = rp as System.Collections.Generic.IDictionary<string, object>;
                                    if (d == null) continue;
                                    string cod = d.ContainsKey("Codigo") ? (d["Codigo"]?.ToString() ?? "") : (d.ContainsKey("Id") ? (d["Id"]?.ToString() ?? "") : "");
                                    string opc = d.ContainsKey("Opcion1") ? (d["Opcion1"]?.ToString() ?? "") : (d.ContainsKey("Opcion") ? (d["Opcion"]?.ToString() ?? "") : "");
                                    var keyCode = !string.IsNullOrWhiteSpace(cod) ? (cod.Trim() + "|" + Normalize(opc)) : null;
                                    var keyName = Normalize(opc);
                                    if (!string.IsNullOrWhiteSpace(keyCode)) set.Add(keyCode);
                                    if (!string.IsNullOrWhiteSpace(keyName)) set.Add("n|" + keyName);
                                }
                            }
                            catch { }
                        }
                    }
                    catch { }
                    perfilPerms[p.codigo] = set;
                }

                var results = new List<object>();
                foreach (var u in users)
                {
                    var userPermSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                    try
                    {
                        var dsU = channel.MostrarPermisos(u.username);
                        var rowsU = DataSetToObjects(dsU);
                        foreach (var ru in rowsU)
                        {
                            var d = ru as System.Collections.Generic.IDictionary<string, object>;
                            if (d == null) continue;
                            string cod = d.ContainsKey("Codigo") ? (d["Codigo"]?.ToString() ?? "") : (d.ContainsKey("CodOpcion") ? (d["CodOpcion"]?.ToString() ?? "") : "");
                            string opc = d.ContainsKey("Opcion1") ? (d["Opcion1"]?.ToString() ?? "") : (d.ContainsKey("Opcion") ? (d["Opcion"]?.ToString() ?? "") : "");
                            var keyCode = !string.IsNullOrWhiteSpace(cod) ? (cod.Trim() + "|" + Normalize(opc)) : null;
                            var keyName = Normalize(opc);
                            if (!string.IsNullOrWhiteSpace(keyCode)) userPermSet.Add(keyCode);
                            if (!string.IsNullOrWhiteSpace(keyName)) userPermSet.Add("n|" + keyName);
                        }
                    }
                    catch { }

                    // if no explicit user perms, try to get perfil from MostrarUsuarioSistema and use perfil's perms
                    if (userPermSet.Count == 0)
                    {
                        try
                        {
                            var dsInfo = channel.MostrarUsuarioSistema(u.username);
                            var rowsInfo = DataSetToObjects(dsInfo);
                            if (rowsInfo.Count > 0)
                            {
                                var d0 = rowsInfo[0] as System.Collections.Generic.IDictionary<string, object>;
                                string? pCod = null;
                                if (d0 != null)
                                {
                                    foreach (var k in new[] { "CodPerfil", "CodigoPerfil", "IdPerfil" }) if (d0.ContainsKey(k) && pCod == null) pCod = d0[k]?.ToString();
                                }
                                if (!string.IsNullOrWhiteSpace(pCod) && perfilPerms.ContainsKey(pCod))
                                {
                                    foreach (var it in perfilPerms[pCod]) userPermSet.Add(it);
                                }
                            }
                        }
                        catch { }
                    }

                    // Score against each profile (prefer name/code normalized overlap)
                    string bestCodigo = null; string bestNombre = null; double bestScore = 0.0;
                    foreach (var p in perfiles)
                    {
                        var pset = perfilPerms.ContainsKey(p.codigo) ? perfilPerms[p.codigo] : new HashSet<string>();
                        if (pset.Count == 0) continue;
                        var intersect = pset.Intersect(userPermSet).Count();
                        var union = pset.Union(userPermSet).Count();
                        double score = union == 0 ? 0.0 : (double)intersect / (double)union;
                        // also try a relaxed name-only score
                        if (score == 0)
                        {
                            var pNames = pset.Where(s => s.StartsWith("n|", StringComparison.OrdinalIgnoreCase)).Select(s => s.Substring(2)).ToHashSet(StringComparer.OrdinalIgnoreCase);
                            var uNames = userPermSet.Where(s => s.StartsWith("n|", StringComparison.OrdinalIgnoreCase)).Select(s => s.Substring(2)).ToHashSet(StringComparer.OrdinalIgnoreCase);
                            var inter = pNames.Intersect(uNames).Count();
                            var uni = pNames.Union(uNames).Count();
                            if (uni > 0) score = (double)inter / (double)uni * 0.9; // slightly lower weight
                        }
                        if (score > bestScore)
                        {
                            bestScore = score; bestCodigo = p.codigo; bestNombre = p.nombre;
                        }
                    }

                    bool isAdmin = false; bool isConsultor = false;
                    if (!string.IsNullOrWhiteSpace(bestCodigo) && bestCodigo.TrimStart('0') == "1") isAdmin = true;
                    if (!isAdmin && !string.IsNullOrWhiteSpace(bestNombre))
                    {
                        var low = bestNombre.ToLowerInvariant();
                        if (low.Contains("admin") || low.Contains("administrador")) isAdmin = true;
                        if (low.Contains("consult" ) || low.Contains("consultor")) isConsultor = true;
                    }

                    results.Add(new { username = u.username, fullName = u.fullName, inferredPerfilCodigo = bestCodigo, inferredPerfilNombre = bestNombre, score = Math.Round(bestScore, 3), isAdmin = isAdmin, isConsultor = isConsultor });
                }

                return Ok(new { source = "inference", count = results.Count, items = results });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"SeguridadService error (infer users): {ex.Message}");
                return Problem(title: "SIGECOM WCF error", detail: ex.Message, statusCode: StatusCodes.Status503ServiceUnavailable);
            }
        }

        private static string Normalize(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return string.Empty;
            var formD = s.ToLowerInvariant().Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();
            foreach (var ch in formD)
            {
                var cat = CharUnicodeInfo.GetUnicodeCategory(ch);
                if (cat != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(ch);
                }
            }
            var cleaned = sb.ToString().Normalize(NormalizationForm.FormC);
            cleaned = Regex.Replace(cleaned, "\\s+", " ").Trim();
            return cleaned;
        }

        private static List<object> DataSetToObjects(DataSet? ds)
        {
            var list = new List<object>();
            if (ds == null || ds.Tables.Count == 0) return list;
            foreach (DataTable table in ds.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    var dict = new Dictionary<string, object?>();
                    foreach (DataColumn col in table.Columns)
                    {
                        try { dict[col.ColumnName] = row[col]?.ToString(); } catch { dict[col.ColumnName] = null; }
                    }
                    list.Add(dict);
                }
            }
            return list;
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
