using Microsoft.EntityFrameworkCore;
using System;
using YakLogApi.Entities;

namespace YakLogApi.Persistence;

public class YakLogDbContext : DbContext
{
    public DbSet<User> Users {  get; set; }

    public YakLogDbContext(DbContextOptions<YakLogDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(YakLogDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
