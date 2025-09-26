using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YakLog.Domain.Entities.MediaItems.Interfaces;

namespace YakLog.Domain.Entities.MediaItems;

public abstract class MediaItem : IFinishable
{
    public long Id { get; set; }
    public required string Title { get; set; }
    public string? ImageFilePath { get; set; }
    public bool Finished { get; set; }
    public DateTime FinishedDate { get; set; }

    public long PortfolioId { get; set; }
    public Portfolio Portfolio { get; set; } = null!;
}
