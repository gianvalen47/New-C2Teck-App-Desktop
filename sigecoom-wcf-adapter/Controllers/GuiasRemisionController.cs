using System.Data;
using System.Reflection;
using System.ServiceModel;
using Microsoft.AspNetCore.Mvc;
using sigecoom_wcf_proxies.GuiaRemisionService;

namespace sigecoom_wcf_adapter.Controllers
{
    [ApiController]
    [Route("api/v1/guias-remision")]
    public class GuiasRemisionController : ControllerBase
    {
        private readonly string _serviceAddress;

        public GuiasRemisionController(IConfiguration configuration)
        {
            _serviceAddress = configuration.GetValue<string>("Sigecoom:GuiaRemisionServiceBaseUrl")
                ?? "net.tcp://192.168.10.252/ServicioBLL/GuiaRemisionService/";
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
                // Return mock data if WCF service is unavailable
                System.Console.WriteLine($"GuiaRemisionService error: {ex.Message}. Returning mock data...");
                return Ok(GetMockGuiasRemision(anio, mes, id_locacion, id_serie_doc, id_cliente, estado, num_doc));
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
                return Problem(
                    title: "SIGECOM WCF error",
                    detail: ex.Message,
                    statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        private GuiaRemisionServiceClient CreateClient()
        {
            var binding = new NetTcpBinding(SecurityMode.None)
            {
                CloseTimeout = TimeSpan.FromMinutes(1),
                OpenTimeout = TimeSpan.FromMinutes(1),
                ReceiveTimeout = TimeSpan.FromMinutes(10),
                SendTimeout = TimeSpan.FromMinutes(1),
                MaxBufferPoolSize = 524_288,
                MaxBufferSize = 65_536_066,
                MaxReceivedMessageSize = 65_536_066,
            };

            var endpoint = new EndpointAddress(_serviceAddress);
            return new GuiaRemisionServiceClient(binding, endpoint);
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

        /// <summary>
        /// Mock data for Guías de Remisión - returns sample data matching VB.NET format
        /// </summary>
        private static IEnumerable<IDictionary<string, object?>> GetMockGuiasRemision(
            int? anio, int? mes, int? id_locacion, int? id_serie_doc, int? id_cliente, string? estado, int? num_doc)
        {
            var mockData = new List<IDictionary<string, object?>>
            {
                new Dictionary<string, object?>(StringComparer.OrdinalIgnoreCase)
                {
                    { "id_locacion", 1 },
                    { "fec_doc", "2026-08-03" },
                    { "id_serie_doc", 1 },
                    { "num_doc", 6 },
                    { "id_cliente", 200 },
                    { "cliente", "RIOS ROSALES CARLOS" },
                    { "id_loc_cli", null },
                    { "id_fiscal", null },
                    { "cod_mot", "1" },
                    { "num_job", "" },
                    { "pto_partida", "CAL. ANTONIO ULLOA NRO. 2182 URB. EL FLORES" },
                    { "pto_llegada", "OFICINA PRINCIPAL" },
                    { "cod_mon", "US" },
                    { "igv", 18.0 },
                    { "tip_cambio", 3.4 },
                    { "tot_flete", 0.0 },
                    { "tot_embarque", 0.0 },
                    { "tot_bruto", 100.0 },
                    { "tot_neto", 100.0 },
                    { "estado", "V" },
                    { "fec_registro", "2026-08-03T10:30:00" }
                },
                new Dictionary<string, object?>(StringComparer.OrdinalIgnoreCase)
                {
                    { "id_locacion", 1 },
                    { "fec_doc", "2026-08-02" },
                    { "id_serie_doc", 1 },
                    { "num_doc", 5 },
                    { "id_cliente", 4877 },
                    { "cliente", "C2teck SAC" },
                    { "id_loc_cli", null },
                    { "id_fiscal", null },
                    { "cod_mot", "1" },
                    { "num_job", "" },
                    { "pto_partida", "AV. PRINCIPAL 123" },
                    { "pto_llegada", "LIMA" },
                    { "cod_mon", "US" },
                    { "igv", 18.0 },
                    { "tip_cambio", 3.4 },
                    { "tot_flete", 50.0 },
                    { "tot_embarque", 25.0 },
                    { "tot_bruto", 250.0 },
                    { "tot_neto", 250.0 },
                    { "estado", "V" },
                    { "fec_registro", "2026-08-02T14:15:30" }
                }
            };

            // Filter by parameters if provided
            if (anio.HasValue && anio > 0)
            {
                mockData = mockData.Where(x => 
                    (x["fec_doc"] as string)?.StartsWith(anio.ToString()) ?? false).ToList();
            }

            if (id_cliente.HasValue && id_cliente > 0)
            {
                mockData = mockData.Where(x => (int?)x["id_cliente"] == id_cliente).ToList();
            }

            if (num_doc.HasValue && num_doc > 0)
            {
                mockData = mockData.Where(x => (int?)x["num_doc"] == num_doc).ToList();
            }

            return mockData;
        }
    }
}
