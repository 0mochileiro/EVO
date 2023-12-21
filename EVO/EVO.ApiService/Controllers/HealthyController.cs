using Microsoft.AspNetCore.Mvc;

namespace EVO.ApiService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthyController : ControllerBase
    {
        public HealthyController()
        {
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new
            {
                Running = true,
                Route = "api/Healthy",
                DateTime = DateTime.UtcNow.ToString("dd/MM/yy")
            });
        }
    }
}
    
