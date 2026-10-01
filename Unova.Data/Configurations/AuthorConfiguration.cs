using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Unova.Domain.Entities;

namespace Unova.Infrastructure.Configurations;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.ToTable("asp_Authors");

        builder.HasKey(x => x.ID);

        builder.Property(x => x.FirstName)
            .IsRequired()
            .HasMaxLength(55);

        builder.Property(x => x.LastName)
            .IsRequired()
            .HasMaxLength(55);
    }
}
