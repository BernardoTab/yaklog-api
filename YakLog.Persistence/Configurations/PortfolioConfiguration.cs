using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YakLog.Domain.Entities;

namespace YakLog.Persistence.Configurations;

public class PortfolioConfiguration : IEntityTypeConfiguration<Portfolio>
{
    public void Configure(EntityTypeBuilder<Portfolio> builder)
    {
        builder.ToTable("Portfolios");

        builder.HasKey(p => p.Id);

        builder.HasOne(p => p.User)
               .WithOne(u => u.Portfolio)
               .HasForeignKey<Portfolio>(p => p.UserId);

        builder.HasMany(p => p.Games)
               .WithOne(g => g.Portfolio)
               .HasForeignKey(g => g.PortfolioId);

        builder.HasMany(p => p.SeriesSeasons)
               .WithOne(s => s.Portfolio)
               .HasForeignKey(s => s.PortfolioId);

        builder.HasMany(p => p.Movies)
               .WithOne(m => m.Portfolio)
               .HasForeignKey(m => m.PortfolioId);

        builder.HasMany(p => p.Books)
               .WithOne(b => b.Portfolio)
               .HasForeignKey(b => b.PortfolioId);

        builder.HasMany(p => p.Projects)
               .WithOne(pr => pr.Portfolio)
               .HasForeignKey(pr => pr.PortfolioId);
    }
}
