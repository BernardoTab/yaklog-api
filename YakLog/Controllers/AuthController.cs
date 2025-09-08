using Microsoft.AspNetCore.Mvc;
using YakLog.DataTransferring.Responses;
using YakLogApi.Dtos;
using YakLogApi.Services.Interfaces;

namespace YakLogApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    [HttpPost("login")]
    public async Task<ActionResult<LoginResponse>> Login(
        [FromServices] IAuthService authService,
        [FromBody] UserInputDto userInput)
    {
        var loginResponse = await authService.LoginAsync(userInput);
        return Ok(loginResponse);
    }

    [HttpPost("register")]
    public async Task<ActionResult<LoginResponse>> Register(
        [FromServices] IAuthService authService,
        [FromBody] UserInputDto userInput)
    {
        var loginResponse = await authService.RegisterAsync(userInput);
        return Ok(loginResponse);
    }
}