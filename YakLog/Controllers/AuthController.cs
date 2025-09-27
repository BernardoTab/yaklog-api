using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using YakLog.DataTransferring.Responses;
using YakLogApi.Dtos;
using YakLogApi.Services.Interfaces;

namespace YakLogApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _config;

    public AuthController(IConfiguration config)
    {
        _config = config;
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login(
        [FromServices] IAuthService authService,
        [FromBody] UserInputDto userInput)
    {
        var loginResponse = await authService.LoginAsync(userInput);

        var security = _config.GetValue<bool>("CookieSettings:Secure");
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,        // Prevents JavaScript access
            Secure = security,          // Only over HTTPS
            SameSite = SameSiteMode.None, // Or Lax depending on frontend
            Path = "/" // must match cookie path
        };

        Response.Cookies.Append("jwt", loginResponse.Token, cookieOptions);
        return Ok(new {email = loginResponse.User.Email});
    }

    [HttpPost("register")]
    public async Task<ActionResult> Register(
        [FromServices] IAuthService authService,
        [FromBody] UserInputDto userInput)
    {
        var loginResponse = await authService.RegisterAsync(userInput);

        var security = _config.GetValue<bool>("CookieSettings:Secure");
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,        // Prevents JavaScript access
            Secure = security,          // Only over HTTPS
            SameSite = SameSiteMode.Lax, // Or Lax depending on frontend
            Path = "/" // must match cookie path
        };

        Response.Cookies.Append("jwt", loginResponse.Token, cookieOptions);

        return Ok(new { email = loginResponse.User.Email });
    }

    [HttpPost("logout")]
    public IActionResult Logout()
    {
        var security = _config.GetValue<bool>("CookieSettings:Secure");
        // Overwrite the cookie with an expired one
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Secure = security, // must match what was used when setting the cookie
            SameSite = SameSiteMode.None, // match login cookie for cross-origin
            Expires = DateTime.UtcNow.AddDays(-1), // expire immediately
            Path = "/" // must match cookie path
        };

        Response.Cookies.Append("jwt", "", cookieOptions);

        return Ok(new { message = "Logged out successfully" });
    }

    [Authorize]
    [HttpGet("me")]
    public IActionResult Me()
    {
        // The [Authorize] attribute ensures this endpoint
        // can only be accessed with a valid JWT cookie
        var email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

        return Ok(new
        {
            Email = email
        });
    }
}