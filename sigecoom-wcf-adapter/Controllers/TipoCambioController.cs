using System.Net;
using System.Net.Security;
using System.Security.Principal;
using System.ServiceModel;
using Microsoft.AspNetCore.Mvc;
using sigecoom_wcf_proxies.MaestroService;

namespace sigecoom_wcf_adapter.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class TipoCambioController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TipoCambioController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("tipo-cambio")]
        public IActionResult Get(
            [FromQuery] string moneda = "US",
            [FromQuery] string? fecha = null)
        {
            var compra = GetValue("SIGECOM_TIPO_CAMBIO_COMPRA", "SIGECOM_TIPO_CAMBIO_COMPRA_REAL");
            var venta = GetValue("SIGECOM_TIPO_CAMBIO_VENTA", "SIGECOM_TIPO_CAMBIO_VENTA_REAL");

            if (compra is null || venta is null)
            {
                return NotFound(new
                {
                    moneda,
                    fecha,
                    error = "No se encontró un tipo de cambio real configurado para SIGECOM en este entorno.",
                    source = "environment"
                });
            }

            return Ok(new
            {
                moneda = moneda.ToUpperInvariant(),
                fecha = fecha ?? DateTime.Today.ToString("dd/MM/yyyy"),
                tipo_cambio_compra = compra,
                tipo_cambio_venta = venta,
                compra,
                venta,
                source = "environment"
            });
        }

        [HttpGet("tipo-cambio-guia")]
        public IActionResult GetTipoCambioGuia(
            [FromQuery] string moneda,
            [FromQuery] DateTime fecha)
        {
            try
            {
                using var client = CreateMaestroClient();
                var value = client.MostrarTipoCambio(moneda, fecha.Date);
                if (!double.IsFinite(value) || value <= 0)
                {
                    return NotFound(new
                    {
                        moneda,
                        fecha = fecha.ToString("yyyy-MM-dd"),
                        error = "SIGECOM no devolvió un tipo de cambio válido para la fecha y moneda seleccionadas."
                    });
                }

                return Ok(new
                {
                    moneda = moneda.ToUpperInvariant(),
                    fecha = fecha.ToString("yyyy-MM-dd"),
                    tipo_cambio = value,
                    source = "MaestroService.MostrarTipoCambio"
                });
            }
            catch (Exception ex)
            {
                return Problem(
                    title: "SIGECOM WCF error",
                    detail: ex.InnerException?.Message ?? ex.Message,
                    statusCode: StatusCodes.Status503ServiceUnavailable);
            }
        }

        private MaestroClient CreateMaestroClient()
        {
            var address = _configuration.GetValue<string>("Sigecoom:MaestroServiceBaseUrl")
                ?? Environment.GetEnvironmentVariable("SIGECOM_MAESTRO_SERVICE_URL")
                ?? "net.tcp://192.168.10.252/ServicioBLL/Maestro/";
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

            var client = new MaestroClient(binding, new EndpointAddress(address));
            var domain = _configuration.GetValue<string>("Sigecoom:Domain")
                ?? Environment.GetEnvironmentVariable("SIGECOM_DOMAIN");
            var username = _configuration.GetValue<string>("Sigecoom:Username")
                ?? Environment.GetEnvironmentVariable("SIGECOM_USERNAME");
            var password = _configuration.GetValue<string>("Sigecoom:Password")
                ?? Environment.GetEnvironmentVariable("SIGECOM_PASSWORD");

            client.ClientCredentials.Windows.ClientCredential =
                !string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password)
                    ? new NetworkCredential(username, password, string.IsNullOrWhiteSpace(domain) ? Environment.UserDomainName : domain)
                    : CredentialCache.DefaultNetworkCredentials;
            client.ClientCredentials.Windows.AllowedImpersonationLevel = TokenImpersonationLevel.Impersonation;
            return client;
        }

        private static decimal? GetValue(params string[] names)
        {
            foreach (var name in names)
            {
                var raw = Environment.GetEnvironmentVariable(name);
                if (string.IsNullOrWhiteSpace(raw))
                {
                    continue;
                }

                if (decimal.TryParse(raw.Replace(",", "."), out var value))
                {
                    return value;
                }
            }

            return null;
        }
    }
}
