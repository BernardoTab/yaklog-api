using YakLog.DataTransferring.Responses;
using YakLogApi.Dtos;

namespace YakLogApi.Services.Interfaces;

public interface IAuthService : IService
{
    Task<LoginResponse> LoginAsync(UserInputDto user);
    Task<LoginResponse> RegisterAsync(UserInputDto user);
}
