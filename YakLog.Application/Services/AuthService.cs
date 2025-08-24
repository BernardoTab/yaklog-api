using Microsoft.Extensions.Logging;
using YakLog.Application.Helpers;
using YakLog.Application.Services;
using YakLog.Persistence.Repositories;
using YakLogApi.Dtos;
using YakLogApi.Entities;
using YakLogApi.Services.Interfaces;

namespace YakLogApi.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _repository;
    private readonly TokenService _tokenService;

    public AuthService(IUserRepository repository, TokenService tokenService)
    {
        _repository = repository;
        _tokenService = tokenService;
    }

    public async Task<string> LoginAsync(UserInputDto userInput)
    {
        var user = await _repository.GetUserByEmailAsync(userInput.Email);
        if(user  == null)
        {
            throw new Exception("Login failed - User does not exist!");
        }

        var isPasswordValid = PasswordHelper.VerifyPasswordHash(
            userInput.Password,
            user.PasswordHash,
            user.PasswordSalt);
        if (!isPasswordValid)
        {
            throw new Exception("Login failed - Password is incorrect!");
        }

        var token = _tokenService.GenerateToken(user.Email);
        if(token == null)
        {
            throw new Exception("Login failed - Could not generate token for user");
        }
        return token;
    }
}
