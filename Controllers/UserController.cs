using FinSystem.Models.DTOs;
using FinSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinSystem.Controllers;

public class UserController(ILogger<UserController> logger, UserService userService) : BaseController
{

    /*[HttpPost]
    public async Task<IActionResult> Register()
    {
        await Task.Delay(500);
        
        return BadRequest();
    }*/

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var token = await userService.LoginAsync(dto);
        
            return Ok(token);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    
}