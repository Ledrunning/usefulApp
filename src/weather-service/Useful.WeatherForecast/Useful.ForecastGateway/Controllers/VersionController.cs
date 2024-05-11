using Microsoft.AspNetCore.Mvc;
using Useful.ForecastGateway.Helpers;

namespace Useful.ForecastGateway.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VersionController : ControllerBase
{
    [HttpGet]
    public IActionResult Index()
    {
        return Ok($"Version - {ProgramRuntime.ProgramVersion}");
    }
}