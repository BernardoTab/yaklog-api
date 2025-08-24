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
        return token;
    }

    public async Task<string> RegisterAsync(UserInputDto userInput)
    {
        var existingUser = await _repository.GetUserByEmailAsync(userInput.Email);
        if (existingUser != null)
        {
            throw new Exception("Registration failed - User with that email already exists!");
        }

        PasswordHelper.CreatePasswordHash(userInput.Password, out byte[] passwordHash, out byte[] passwordSalt);

        await _repository.AddAsync(new User
        {
            Email = userInput.Email,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt
        });

        var token = _tokenService.GenerateToken(userInput.Email);
        return token;
    }
}
