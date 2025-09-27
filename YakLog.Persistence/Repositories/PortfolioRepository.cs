using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YakLog.Domain.Entities;
using YakLog.Domain.Entities.MediaItems;
using YakLog.Persistence.Repositories.Interfaces;
using YakLogApi.Entities;
using YakLogApi.Persistence;

namespace YakLog.Persistence.Repositories;

public class PortfolioRepository : BaseRepository<Portfolio>, IPortfolioRepository
{
    public PortfolioRepository(YakLogDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<Portfolio?> GetPortfolioByUserIdAsync(long id)
    {
        return await _dbSet.FirstOrDefaultAsync(p => p.UserId == id);
    }

    public async Task AddMediaItemToPortfolioAsync(MediaItem mediaItem, Portfolio portfolio)
    {
        mediaItem.Portfolio = portfolio;
        portfolio.MediaItems.Add(mediaItem);
        await _dbContext.SaveChangesAsync();
    }
}