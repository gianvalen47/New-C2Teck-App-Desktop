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
    [DataContract(Name = "Cliente", Namespace = "http://schemas.datacontract.org/2004/07/Models")]
    public class Cliente
    {
        [DataMember] public string? AbrCli { get; set; }
        [DataMember] public string? ApeMat { get; set; }
        [DataMember] public string? ApePat { get; set; }
        [DataMember] public bool AprCli { get; set; }
        [DataMember] public string? CodUbigeo { get; set; }
        [DataMember] public string? CodUsu { get; set; }
        [DataMember] public string? DesCli { get; set; }
        [DataMember] public string? DiaPago { get; set; }
        [DataMember] public string? DirIp { get; set; }
        [DataMember] public string? Direccion { get; set; }
        [DataMember] public string? DniCli { get; set; }
        [DataMember] public string? DueCli { get; set; }
        [DataMember] public string? Email { get; set; }
        [DataMember] public int Estado { get; set; }
        [DataMember] public string? FaxCli { get; set; }
        [DataMember] public DateTime FecIng { get; set; }
        [DataMember] public string? HoraPago { get; set; }
        [DataMember] public int IdCliente { get; set; }
        [DataMember] public double LimiteCredito { get; set; }
        [DataMember] public bool ListaCli { get; set; }
        [DataMember] public string? NomDepartamento { get; set; }
        [DataMember] public string? NomDistrito { get; set; }
        [DataMember] public string? NomPc { get; set; }
        [DataMember] public string? NomProvincia { get; set; }
        [DataMember] public string? Nombres { get; set; }
        [DataMember] public string? NumCta { get; set; }
        [DataMember] public string? ObsCli { get; set; }
        [DataMember] public bool Retenedor { get; set; }
        [DataMember] public string? RucCli { get; set; }
        [DataMember] public string? TelCli { get; set; }
        [DataMember] public string? UrlCli { get; set; }
    }

    [ServiceContract(Name = "IClienteService", Namespace = "http://tempuri.org/")]
    public interface IClienteService
    {
        [OperationContract(Action = "http://tempuri.org/IClienteService/Filtrar", ReplyAction = "http://tempuri.org/IClienteService/FiltrarResponse")]
        DataSet Filtrar(string pCodEmp, Cliente Clase);

        [OperationContract(Action = "http://tempuri.org/IClienteService/MostrarPorID", ReplyAction = "http://tempuri.org/IClienteService/MostrarPorIDResponse")]
        Cliente MostrarPorID(int pIdCliente);
    }

    [ApiController]
    [Route("api/v1/clients")]
    public class ClientesController : ControllerBase
    {
        private readonly string _serviceAddress;
        private readonly string _companyCode;
        private readonly string? _domain;
        private readonly string? _username;
        private readonly string? _password;

        public ClientesController(IConfiguration configuration)
        {
            _serviceAddress = configuration.GetValue<string>("Sigecoom:ClienteServiceBaseUrl")
                ?? Environment.GetEnvironmentVariable("SIGECOM_CLIENTE_SERVICE_URL")
                ?? "net.tcp://192.168.10.252/ServicioBLL/ClienteService/";

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

        [HttpGet]
        public IActionResult Get(
            [FromQuery] int? id,
            [FromQuery] string? nombre,
            [FromQuery] string? ruc,
            [FromQuery] string? dni)
        {
            try
            {
                var filtro = new Cliente();

                if (id.HasValue)
                {
                    filtro.IdCliente = id.Value;
                }

                if (!string.IsNullOrWhiteSpace(nombre))
                {
                    filtro.DesCli = nombre;
                }

                if (!string.IsNullOrWhiteSpace(ruc))
                {
                    filtro.RucCli = ruc;
                }

                if (!string.IsNullOrWhiteSpace(dni))
                {
                    filtro.DniCli = dni;
                }

                var channel = CreateClient();
                var dataset = channel.Filtrar(_companyCode, filtro);
                return Ok(ParseClientRows(dataset));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ClienteService error: {ex.Message}");
                Console.WriteLine($"Inner exception: {ex.InnerException?.Message}");
                return Problem(
                    title: "SIGECOM WCF error",
                    detail: ex.InnerException?.Message ?? ex.Message,
                    statusCode: StatusCodes.Status503ServiceUnavailable);
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var channel = CreateClient();
                var item = channel.MostrarPorID(id);
                return Ok(ConvertToDictionary(item));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ClienteService error on GetById({id}): {ex.Message}");
                return Problem(
                    title: "SIGECOM WCF error",
                    detail: ex.Message,
                    statusCode: StatusCodes.Status503ServiceUnavailable);
            }
        }

        private IClienteService CreateClient()
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

            var factory = new ChannelFactory<IClienteService>(binding, new EndpointAddress(_serviceAddress));

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

        private static IEnumerable<IDictionary<string, object?>> ParseClientRows(DataSet? dataset)
        {
            if (dataset == null || dataset.Tables.Count == 0)
            {
                return Array.Empty<IDictionary<string, object?>>();
            }

            var table = dataset.Tables[0];
            var results = new List<IDictionary<string, object?>>();
            var columns = table.Columns.Cast<DataColumn>().ToArray();

            foreach (DataRow row in table.Rows)
            {
                var record = new Dictionary<string, object?>(StringComparer.OrdinalIgnoreCase);
                foreach (var column in columns)
                {
                    record[column.ColumnName] = row.IsNull(column)
                        ? null
                        : ConvertToJsonCompatible(row[column]);
                }

                results.Add(record);
            }

            return results;
        }

        private static object? ConvertToJsonCompatible(object? value)
        {
            if (value == null || value is DBNull)
            {
                return null;
            }

            return value switch
            {
                DateTime dateTime => dateTime.ToString("o"),
                Enum @enum => @enum.ToString(),
                _ => value,
            };
        }

        private static object? ConvertToDictionary(object? source, int depth = 0)
        {
            if (source == null || depth > 5)
            {
                return null;
            }

            if (source is string || source is ValueType)
            {
                return source;
            }

            if (source is IEnumerable<object> enumerable)
            {
                return enumerable.Select(item => ConvertToDictionary(item, depth + 1)).ToArray();
            }

            var type = source.GetType();
            var properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            var dict = new Dictionary<string, object?>(StringComparer.OrdinalIgnoreCase);

            foreach (var property in properties)
            {
                if (property.GetIndexParameters().Length > 0)
                {
                    continue;
                }

                var value = property.GetValue(source);
                dict[property.Name] = ConvertToDictionary(value, depth + 1);
            }

            return dict;
        }
    }
}
