using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YakLog.Domain.Entities.MediaItems;
using YakLogApi.Entities;

namespace YakLog.Domain.Entities;

public class Portfolio
{
    public long Id { get; set; }
    public ICollection<MediaItem> MediaItems { get; set; } = new List<MediaItem>();

    // Foreign key for 1-to-1 with User
    public long UserId { get; set; }
    public User User { get; set; } = null!;

}
