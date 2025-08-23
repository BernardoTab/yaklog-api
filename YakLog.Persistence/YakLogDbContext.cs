using Microsoft.EntityFrameworkCore;
using System;
using YakLogApi.Entities;

namespace YakLogApi.Persistence;

public class YakLogDbContext : DbContext
{
    public DbSet<User> Users {  get; set; }

    public YakLogDbContext(DbContextOptions<YakLogDbContext> options)
        : base(options) { }
}
