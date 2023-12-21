using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EVO.Repository.Data;
using EVO.ApiService.Controllers.Abstractions;

namespace EVO.ApiService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthyController : AbstractController
    {
        public HealthyController(DbContextOptions<Context> dbContextOptions) : base(dbContextOptions)
        {
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new
            {
                Running = true,
                Route = "api/Healthy",
                DateTime = DateTime.UtcNow
            });
        }
    }
}

