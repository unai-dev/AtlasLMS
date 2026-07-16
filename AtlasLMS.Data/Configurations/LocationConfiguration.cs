using AtlasLMS.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasLMS.Data.Configurations;

public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.Property(x => x.Aisle)
            .IsRequired()
            .HasMaxLength(5);
        
        builder.Property(x => x.Shelf)
            .IsRequired()
            .HasMaxLength(5);
        
        builder.Property(x => x.Column)
            .IsRequired()
            .HasMaxLength(5);
    }
}
