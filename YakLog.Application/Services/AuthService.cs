using Microsoft.Extensions.Logging;
using YakLog.Persistence.Repositories;
using YakLogApi.Dtos;
using YakLogApi.Services.Interfaces;

namespace YakLogApi.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _repository;

    public AuthService(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task LoginAsync(UserInputDto userInput)
    {
        var user = await _repository.GetByIdAsync(2);
        if(user  == null)
        {
            throw new Exception("User doesnt exist!");
        }
    }
}
