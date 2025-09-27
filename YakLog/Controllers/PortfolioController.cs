using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using YakLog.Application.Services.Interfaces;
using YakLog.DataTransferring.Dtos;
using YakLog.DataTransferring.Responses;
using YakLogApi.Dtos;
using YakLogApi.Services.Interfaces;

namespace YakLog.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PortfolioController : ControllerBase
{
    [HttpPost("add-item")]
    [Authorize]
    public async Task<ActionResult> AddMediaItem(
        [FromServices] IPortfolioService portfolioService,
        [FromBody] MediaItemInputDto mediaItemInput)
    {
        string? email = User.FindFirst(ClaimTypes.Email)?.Value;
        if (email == null) return Unauthorized();

        await portfolioService.AddMediaItemAsync(mediaItemInput, email);
        return Ok();
    }
}