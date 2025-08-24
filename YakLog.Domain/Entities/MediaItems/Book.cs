using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YakLog.Domain.Entities.MediaItems.Interfaces;

namespace YakLog.Domain.Entities.MediaItems;

public class Book : MediaItem, IFinishable
{
    public required string Author { get; set; }
    public bool Finished { get; set; }
    public DateTime FinishedDate { get; set; }
}
