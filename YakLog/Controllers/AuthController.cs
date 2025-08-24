using Microsoft.AspNetCore.Mvc;
using YakLogApi.Dtos;
using YakLogApi.Services.Interfaces;

namespace YakLogApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    [HttpPost("login")]
    public async Task<ActionResult<string>> Login(
        [FromServices] IAuthService authService,
        [FromBody] UserInputDto userInput)
    {
        var token = await authService.LoginAsync(userInput);
        return Ok(token);
    }

    [HttpPost("register")]
    public async Task<ActionResult<string>> Register(
        [FromServices] IAuthService authService,
        [FromBody] UserInputDto userInput)
    {
        var token = await authService.RegisterAsync(userInput);
        return Ok(token);
    }
}