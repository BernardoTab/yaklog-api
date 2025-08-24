using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YakLog.Domain.Entities.MediaItems;

namespace YakLog.Domain.Entities;

public class Portfolio
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public ICollection<Game> Games { get; set; } = new List<Game>();
    public ICollection<Series> Series { get; set; } = new List<Series>();
    public ICollection<Movie> Movies { get; set; } = new List<Movie>();
    public ICollection<Book> Books { get; set; } = new List<Book>();
    public ICollection<Project> Projects { get; set; } = new List<Project>();
}
