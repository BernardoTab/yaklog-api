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
        builder.HasKey(m => m.Id);

        builder.Property(m => m.Title)
               .IsRequired()
               .HasMaxLength(200);

        builder.Property(m => m.ImageFilePath);
        builder.Property(m => m.Finished);
        builder.Property(m => m.FinishedDate);

        builder.HasDiscriminator<string>("MediaType")
            .HasValue<Game>("Game")
            .HasValue<Book>("Book")
            .HasValue<Movie>("Movie")
            .HasValue<SeriesSeason>("SeriesSeason")
            .HasValue<Project>("Project");

        builder.HasOne(m => m.Portfolio)
               .WithMany() 
               .HasForeignKey(m => m.PortfolioId);
    }
}