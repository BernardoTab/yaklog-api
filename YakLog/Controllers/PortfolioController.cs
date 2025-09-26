using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        await portfolioService.AddMediaItemAsync(mediaItemInput);
        return Ok();
    }
}