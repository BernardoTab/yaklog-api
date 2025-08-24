using YakLogApi.Dtos;

namespace YakLogApi.Services.Interfaces;

public interface IAuthService : IService
{
    Task<string> LoginAsync(UserInputDto user);
}
