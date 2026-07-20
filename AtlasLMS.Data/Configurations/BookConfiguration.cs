using AtlasLMS.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasLMS.Data.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(55);

        builder.Property(x => x.ISBN)
            .IsRequired()
            .HasMaxLength(13);

        builder.Property(x => x.Synopsis)
            .HasMaxLength(255);

        builder.Property(x => x.PublicationAt)
            .IsRequired();

        builder.Property(x => x.Stock)
            .HasDefaultValue(1);
    }
}
