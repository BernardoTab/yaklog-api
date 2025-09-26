using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YakLog.Domain.Entities.MediaItems;

namespace YakLog.Persistence.Configurations;

public class SeriesSeasonConfiguration : IEntityTypeConfiguration<SeriesSeason>
{
    public void Configure(EntityTypeBuilder<SeriesSeason> builder)
    {
        builder.ToTable("SeriesSeasons");

        builder.Property(ss => ss.SeasonNumber)
               .IsRequired();
    }
}