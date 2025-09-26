using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YakLog.DataTransferring.Dtos;
using YakLogApi.Services.Interfaces;

namespace YakLog.Application.Services.Interfaces;

public interface IPortfolioService : IService
{
    Task AddMediaItemAsync(MediaItemInputDto mediaItemInputDto);
}
