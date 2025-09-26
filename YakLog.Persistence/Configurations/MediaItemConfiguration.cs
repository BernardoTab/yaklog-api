using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YakLog.Domain.Entities.MediaItems;

namespace YakLog.Persistence.Configurations;

public class MediaItemConfiguration : IEntityTypeConfiguration<MediaItem>
{
    public void Configure(EntityTypeBuilder<MediaItem> builder)
    {
        // Mark this hierarchy as TPC
        builder.UseTpcMappingStrategy();

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Title)
               .IsRequired()
               .HasMaxLength(200);

        builder.HasOne(m => m.Portfolio)
               .WithMany() // concrete classes (Game, Movie, etc.) will have their own collections
               .HasForeignKey(m => m.PortfolioId);
    }
}