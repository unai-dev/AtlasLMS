using System;
using System.Collections.Generic;
using System.Text;

using AtlasLMS.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasLMS.Data.Configurations;

public class CenterConfiguration: IEntityTypeConfiguration<Center>
{
    public void Configure(EntityTypeBuilder<Center> builder)
    {
        builder.ToTable("asp_Centers");

        builder.HasKey(x => x.ID);

        builder.Property(x => x.Name)
            .HasMaxLength(55)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasMaxLength(2000);

        builder.Property(x => x.Abbreviation)
            .HasMaxLength(3)
            .IsRequired();
    }

}
