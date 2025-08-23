using YakLogApi.Dtos;

namespace YakLogApi.Services.Interfaces;

public interface IAuthService : IService
{
    Task LoginAsync(UserInputDto user);
}
