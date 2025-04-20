using Microsoft.AspNetCore.Mvc;

namespace FinSystem.Controllers;

public class HealthController(ILogger<HealthController> logger) : BaseController
{
    [HttpGet("ping")]
    public IActionResult Ping()
    {
        logger.LogInformation("Health check");
        
        return Ok("pong");
    }
}