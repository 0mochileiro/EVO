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

        [HttpGet("GetHealthy")]
        public IActionResult GetHealthy()
        {
            var version = _Entities.ApplicationVersionRepository
                .GetVersion();

            return Ok(new
            {
                Working = true,
                ExecutionDataTime = DateTime.UtcNow,
                ApplicationVersion  = version
            });
        }

        [HttpGet("GetApplicationVersion")]
        public IActionResult GetApplicationVersion()
        {
            var applicationVersion = _Entities.ApplicationVersionRepository
                .GetApplicationVersionWithComponent();

            return Ok(new
            {
                Version = applicationVersion,
                Label = applicationVersion.ApplicationVersionLabel,
                Components = applicationVersion.ApplicationVersionComponent,
                Scripts = applicationVersion.ApplicationVersionScript
            });
        }
    }
}

