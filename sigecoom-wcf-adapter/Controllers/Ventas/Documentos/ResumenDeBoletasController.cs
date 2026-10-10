using System.Data;
using System.Net;
using System.Net.Security;
using System.Reflection;
using System.Security.Principal;
using System.ServiceModel;
using Microsoft.AspNetCore.Mvc;
using sigecoom_wcf_proxies.ResumenBoletasDigitalService;

namespace sigecoom_wcf_adapter.Controllers
{
    [ApiController]
    [Route("api/v1/resumen-boletas")]
    public class ResumenDeBoletasController : ControllerBase
    {
        private readonly string _serviceAddress;
        private readonly string? _domain;
        private readonly string? _username;
        private readonly string? _password;

        public ResumenDeBoletasController(IConfiguration configuration)
        {
            _serviceAddress = configuration.GetValue<string>("Sigecoom:ResumenBoletasServiceBaseUrl")
                ?? Environment.GetEnvironmentVariable("SIGECOM_RESUMEN_BOLETAS_SERVICE_URL")
                ?? "net.tcp://192.168.10.252/ServicioBLL/ResumenBoletasDigitalService/";

            _domain = configuration.GetValue<string>("Sigecoom:Domain")
                ?? Environment.GetEnvironmentVariable("SIGECOM_DOMAIN");
            _username = configuration.GetValue<string>("Sigecoom:Username")
                ?? Environment.GetEnvironmentVariable("SIGECOM_USERNAME");
            _password = configuration.GetValue<string>("Sigecoom:Password")
                ?? Environment.GetEnvironmentVariable("SIGECOM_PASSWORD");
        }

        [HttpGet]
        public IActionResult Get(
            [FromQuery] string? cod_emp,
            [FromQuery] int? anio,
            [FromQuery] int? mes,
            [FromQuery] string? id_resumen)
        {
            try
            {
                using var client = CreateClient();
                var dataset = client.Filtrar(
                    cod_emp ?? "08",
                    anio ?? 0,
                    mes ?? 0,
                    id_resumen ?? string.Empty);

                return Ok(ParseDataRows(dataset));
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"ResumenBoletasDigitalService error: {ex.Message}");
                System.Console.WriteLine($"Inner exception: {ex.InnerException?.Message}");
                return Problem(
                    title: "SIGECOM WCF error",
                    detail: ex.InnerException?.Message ?? ex.Message,
                    statusCode: StatusCodes.Status503ServiceUnavailable);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id, [FromQuery] string? cod_emp)
        {
            try
            {
                using var client = CreateClient();
                var resumen = client.Obtener(id, cod_emp ?? "08");
                return Ok(ConvertToDictionary(resumen));
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"ResumenBoletasDigitalService error on GetById({id}): {ex.Message}");
                return Problem(
                    title: "SIGECOM WCF error",
                    detail: ex.Message,
                    statusCode: StatusCodes.Status503ServiceUnavailable);
            }
        }

        [HttpGet("{id}/detalles")]
        public IActionResult GetDetalles(string id, [FromQuery] string? cod_emp)
        {
            try
            {
                using var client = CreateClient();
                var dataset = client.MostrarDetalles(id, cod_emp ?? "08");
                return Ok(ParseDataRows(dataset));
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"ResumenBoletasDigitalService error on GetDetalles({id}): {ex.Message}");
                return Problem(
                    title: "SIGECOM WCF error",
                    detail: ex.Message,
                    statusCode: StatusCodes.Status503ServiceUnavailable);
            }
        }

        private ResumenBoletasDigitalServiceClient CreateClient()
        {
            var binding = new NetTcpBinding(SecurityMode.Transport)
            {
                CloseTimeout = TimeSpan.FromMinutes(1),
                OpenTimeout = TimeSpan.FromMinutes(1),
                ReceiveTimeout = TimeSpan.FromMinutes(10),
                SendTimeout = TimeSpan.FromMinutes(1),
                MaxBufferPoolSize = 524_288,
                MaxBufferSize = 65_536_066,
                MaxReceivedMessageSize = 65_536_066,
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

            var endpoint = new EndpointAddress(_serviceAddress);
            var client = new ResumenBoletasDigitalServiceClient(binding, endpoint);

            if (!string.IsNullOrWhiteSpace(_username) && !string.IsNullOrWhiteSpace(_password))
            {
                client.ClientCredentials.Windows.ClientCredential = new NetworkCredential(
                    _username,
                    _password,
                    string.IsNullOrWhiteSpace(_domain) ? Environment.UserDomainName : _domain);
                client.ClientCredentials.Windows.AllowedImpersonationLevel = TokenImpersonationLevel.Impersonation;
            }
            else
            {
                client.ClientCredentials.Windows.ClientCredential = CredentialCache.DefaultNetworkCredentials;
                client.ClientCredentials.Windows.AllowedImpersonationLevel = TokenImpersonationLevel.Impersonation;
            }

            return client;
        }

        private static IEnumerable<IDictionary<string, object?>> ParseDataRows(DataSet? dataset)
        {
            if (dataset == null || dataset.Tables.Count == 0)
                return Array.Empty<IDictionary<string, object?>>();
            return ParseDataTable(dataset.Tables[0]);
        }

        private static IEnumerable<IDictionary<string, object?>> ParseDataTable(DataTable? table)
        {
            if (table == null)
                return Array.Empty<IDictionary<string, object?>>();

            var columns = table.Columns.Cast<DataColumn>().ToArray();
            var results = new List<IDictionary<string, object?>>();

            foreach (DataRow row in table.Rows)
            {
                var record = new Dictionary<string, object?>(StringComparer.OrdinalIgnoreCase);
                foreach (var column in columns)
                {
                    record[column.ColumnName] = row.IsNull(column) ? null : ConvertToJsonCompatible(row[column]);
                }
                results.Add(record);
            }

            return results;
        }

        private static object? ConvertToJsonCompatible(object? value)
        {
            if (value == null || value is DBNull) return null;
            return value switch
            {
                DateTime dateTime => dateTime.ToString("o"),
                Enum @enum => @enum.ToString(),
                _ => value,
            };
        }

        private static object? ConvertToDictionary(object? source, int depth = 0)
        {
            if (source == null || depth > 5) return null;
            if (source is string || source is ValueType) return source;
            if (source is IEnumerable<object> enumerable)
                return enumerable.Select(item => ConvertToDictionary(item, depth + 1)).ToArray();

            var type = source.GetType();
            var properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            var dict = new Dictionary<string, object?>(StringComparer.OrdinalIgnoreCase);

            foreach (var property in properties)
            {
                if (property.GetIndexParameters().Length > 0) continue;
                var value = property.GetValue(source);
                dict[property.Name] = ConvertToDictionary(value, depth + 1);
            }

            return dict;
        }
    }
}
