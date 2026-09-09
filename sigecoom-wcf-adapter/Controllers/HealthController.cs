using Microsoft.AspNetCore.Mvc;

namespace sigecoom_wcf_adapter.Controllers
{
    [ApiController]
    [Route("")]
    public class HealthController : ControllerBase
    {
        [HttpGet("health")]
        public IActionResult Get()
        {
            return Ok(new { status = "ok" });
        }
    }
}
