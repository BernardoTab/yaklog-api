using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YakLog.Domain.Entities;
using YakLog.Domain.Entities.MediaItems;

namespace YakLog.Persistence.Repositories.Interfaces;
public interface IPortfolioRepository
{
    Task<Portfolio?> GetPortfolioByUserIdAsync(long id);
    Task AddMediaItemToPortfolioAsync(MediaItem mediaItem, Portfolio portfolio);
}
