using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Unova.Domain.Entities;

namespace Unova.Infrastructure.Configurations;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("asp_Addresses");

        builder.HasKey(x => x.ID);

        builder.Property(x => x.MainAddress)
            .HasMaxLength(2000)
            .IsRequired();

        builder.Property(x => x.SecondAddress)
            .HasMaxLength(2000);

        builder.Property(x => x.PostalCode)
            .HasMaxLength(5)
            .IsRequired();

        builder.Property(x => x.Country)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(x => x.City)
            .HasMaxLength(255)
            .IsRequired();
    }
}
