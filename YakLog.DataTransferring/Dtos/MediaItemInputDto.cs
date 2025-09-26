using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YakLog.DataTransferring.Dtos.Enums;

namespace YakLog.DataTransferring.Dtos;

public class MediaItemInputDto
{
    public required string Title { get; set; }
    public required MediaTypeDto MediaType { get; set; }
    public bool Finished { get; set; }
    public DateTime? FinishedDate { get; set; }
    public string? ImageFilePath { get; set; }

    public string? Author { get; set; }
    public string? Console { get; set; }
    public DateTime? ReleaseDate { get; set; }
    public string? Director { get; set; }
    public int? NumberOfSeasons { get; set; }
}
