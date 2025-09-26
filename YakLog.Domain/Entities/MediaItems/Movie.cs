using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YakLog.Domain.Entities.MediaItems.Interfaces;

namespace YakLog.Domain.Entities.MediaItems;

public class Movie : MediaItem
{
    public DateTime? ReleaseDate { get; set; }
    public string? Director { get; set; }
}
