using Microsoft.AspNetCore.Mvc;

namespace FinSystem.Controllers;


[ApiController]
[Route("api/[controller]")]
public class HealthController : ControllerBase
{
    [HttpGet("ping")]
    public IActionResult Ping()
    {
        return Ok("pong");
    }
}