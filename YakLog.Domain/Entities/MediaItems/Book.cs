using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YakLog.Domain.Entities.MediaItems;

public class Book : MediaItem
{
    public required string Author { get; set; }
}
