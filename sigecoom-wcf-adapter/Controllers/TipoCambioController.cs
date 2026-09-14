using Microsoft.AspNetCore.Mvc;

namespace sigecoom_wcf_adapter.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class TipoCambioController : ControllerBase
    {
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
