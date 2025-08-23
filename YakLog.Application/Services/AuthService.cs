using Microsoft.Extensions.Logging;
using YakLogApi.Dtos;
using YakLogApi.Services.Interfaces;

namespace YakLogApi.Services;

public class AuthService : IAuthService
{
    private readonly ILogger<AuthService> _logger;

    public AuthService(ILogger<AuthService> logger)
    {
        _logger = logger;
    }

    public Task LoginAsync(UserInputDto user)
    {
        _logger.LogInformation("Hello! I am a service");
        return Task.CompletedTask;
    }
}
