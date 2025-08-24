using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YakLog.Domain.Entities.MediaItems;

public abstract class MediaItem
{
    public long Id { get; set; }
    public required string Title { get; set; }
    public bool Finished { get; set; }
    public DateTime FinishedDate { get; set; }
    public string? ImageFilePath { get; set; }
}
