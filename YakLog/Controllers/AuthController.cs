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
        await authService.LoginAsync(userInput);
        return Ok();
    }
}