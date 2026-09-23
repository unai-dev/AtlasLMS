using AtlasLMS.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasLMS.Data.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("asp_Categories");

        builder.HasKey(x => x.ID);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(55);
    }
}
