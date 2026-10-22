using System.Data;
using System.Net;
using System.Net.Security;
using System.Reflection;
using System.Security.Principal;
using System.ServiceModel;
using Microsoft.AspNetCore.Mvc;
using sigecoom_wcf_proxies.GuiaRemisionService;
using sigecoom_wcf_proxies.GuiaRemisionDetService;

namespace sigecoom_wcf_adapter.Controllers
{
    [ApiController]
    [Route("api/v1/guias-remision")]
    public class GuiasRemisionController : ControllerBase
    {
        private readonly string _serviceAddress;
        private readonly string _detailsServiceAddress;
        private readonly string? _domain;
        private readonly string? _username;
        private readonly string? _password;

        public GuiasRemisionController(IConfiguration configuration)
        {
            _serviceAddress = configuration.GetValue<string>("Sigecoom:GuiaRemisionServiceBaseUrl")
                ?? Environment.GetEnvironmentVariable("SIGECOM_SERVICE_URL")
                ?? "net.tcp://192.168.10.252/ServicioBLL/GuiaRemisionService/";
            _detailsServiceAddress = configuration.GetValue<string>("Sigecoom:GuiaRemisionDetServiceBaseUrl")
                ?? Environment.GetEnvironmentVariable("SIGECOM_GUIA_REMISION_DET_SERVICE_URL")
                ?? "net.tcp://192.168.10.252/ServicioBLL/GuiaRemisionDetService/";

            _domain = configuration.GetValue<string>("Sigecoom:Domain")
                ?? Environment.GetEnvironmentVariable("SIGECOM_DOMAIN");
            _username = configuration.GetValue<string>("Sigecoom:Username")
                ?? Environment.GetEnvironmentVariable("SIGECOM_USERNAME");
            _password = configuration.GetValue<string>("Sigecoom:Password")
                ?? Environment.GetEnvironmentVariable("SIGECOM_PASSWORD");
        }

        [HttpGet]
        public IActionResult Get(
            [FromQuery] int? anio,
            [FromQuery] int? mes,
            [FromQuery] int? id_locacion,
            [FromQuery] int? id_serie_doc,
            [FromQuery] int? id_cliente,
            [FromQuery] string? estado,
            [FromQuery] int? num_doc)
        {
            try
            {
                using var client = CreateClient();
                var dataset = client.Filtrar(
                    anio ?? 0,
                    mes ?? 0,
                    id_locacion ?? 0,
                    id_serie_doc ?? 0,
                    id_cliente ?? 0,
                    estado ?? string.Empty,
                    num_doc ?? 0);

                return Ok(ParseGuiaRemisionRows(dataset));
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"GuiaRemisionService error: {ex.Message}");
                System.Console.WriteLine($"Inner exception: {ex.InnerException?.Message}");
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
                using var client = CreateClient();
                var guia = client.MostrarPorId(id);
                return Ok(ConvertToDictionary(guia));
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"GuiaRemisionService error on GetById({id}): {ex.Message}");
                return Problem(
                    title: "SIGECOM WCF error",
                    detail: ex.Message,
                    statusCode: StatusCodes.Status503ServiceUnavailable);
            }
        }

        [HttpGet("{id:int}/detalles")]
        public IActionResult GetDetalles(int id)
        {
            try
            {
                using var client = CreateDetailsClient();
                var dataset = client.Mostrar(id);
                return Ok(ParseGuiaRemisionDetails(dataset, id));
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"GuiaRemisionDetService error on Mostrar({id}): {ex.Message}");
                return Problem(
                    title: "SIGECOM WCF error",
                    detail: ex.InnerException?.Message ?? ex.Message,
                    statusCode: StatusCodes.Status503ServiceUnavailable);
            }
        }

        private GuiaRemisionServiceClient CreateClient()
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
            var client = new GuiaRemisionServiceClient(binding, endpoint);

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

        private GuiaRemisionDetServiceClient CreateDetailsClient()
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

            var client = new GuiaRemisionDetServiceClient(binding, new EndpointAddress(_detailsServiceAddress));
            if (!string.IsNullOrWhiteSpace(_username) && !string.IsNullOrWhiteSpace(_password))
            {
                client.ClientCredentials.Windows.ClientCredential = new NetworkCredential(
                    _username,
                    _password,
                    string.IsNullOrWhiteSpace(_domain) ? Environment.UserDomainName : _domain);
            }
            else
            {
                client.ClientCredentials.Windows.ClientCredential = CredentialCache.DefaultNetworkCredentials;
            }

            client.ClientCredentials.Windows.AllowedImpersonationLevel = TokenImpersonationLevel.Impersonation;
            return client;
        }

        private static IEnumerable<IDictionary<string, object?>> ParseGuiaRemisionRows(DataSet? dataset)
        {
            if (dataset == null || dataset.Tables.Count == 0)
            {
                return Array.Empty<IDictionary<string, object?>>();
            }

            var table = dataset.Tables[0];
            var columns = table.Columns.Cast<DataColumn>().ToArray();
            var results = new List<IDictionary<string, object?>>();

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

        private static IEnumerable<IDictionary<string, object?>> ParseGuiaRemisionDetails(DataSet? dataset, int idGuia)
        {
            if (dataset == null || dataset.Tables.Count == 0)
            {
                return Array.Empty<IDictionary<string, object?>>();
            }

            var table = dataset.Tables[0];
            var results = new List<IDictionary<string, object?>>();
            foreach (DataRow row in table.Rows)
            {
                var description = ReadValue(row, "DesMer", "Descripcion")
                    ?? string.Join(" ", new[]
                    {
                        ReadValue(row, "DesMer1", "Descripcion1"),
                        ReadValue(row, "DesMer2", "Descripcion2"),
                    }.Where(value => !string.IsNullOrWhiteSpace(value)));

                results.Add(new Dictionary<string, object?>(StringComparer.OrdinalIgnoreCase)
                {
                    ["id"] = ReadValue(row, "IdGuiaDet", "Id", "IdDetalle"),
                    ["id_guia"] = ReadValue(row, "IdGuia") is { } rowGuiaId ? rowGuiaId : idGuia,
                    ["item"] = ReadValue(row, "Item"),
                    ["cod_mer"] = ReadValue(row, "CodMer", "Codigo"),
                    ["des_mer"] = description,
                    ["cod_uni_med"] = ReadValue(row, "CodUniMed"),
                    ["can_mer"] = ReadValue(row, "CanMer", "Cantidad"),
                    ["pre_mer"] = ReadValue(row, "PreMer", "Precio"),
                    ["dsc_mer"] = ReadValue(row, "DscMer", "Descuento"),
                    ["total_fila"] = ReadValue(row, "TotalFila", "Total"),
                    ["total_suger"] = ReadValue(row, "TotalFilaSug", "TotalSuger"),
                    ["id_sugerido_cab"] = ReadValue(row, "IdSugeridoCab"),
                    ["regalo"] = ReadValue(row, "Regalo"),
                    ["no_core"] = ReadValue(row, "NoCore"),
                });
            }

            return results;
        }

        private static string? ReadValue(DataRow row, params string[] names)
        {
            foreach (var name in names)
            {
                var column = row.Table.Columns
                    .Cast<DataColumn>()
                    .FirstOrDefault(candidate => string.Equals(candidate.ColumnName, name, StringComparison.OrdinalIgnoreCase));
                if (column != null && !row.IsNull(column))
                {
                    return Convert.ToString(row[column], System.Globalization.CultureInfo.InvariantCulture);
                }
            }

            return null;
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
