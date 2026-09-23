using AtlasLMS.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasLMS.Data.Configurations;

public class BookingConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.ToTable("asp_Bookings");

        builder.HasKey(x => x.ID);

        builder.Property(x => x.StartTime)
            .IsRequired();

        builder.Property(x => x.Status)
            .HasDefaultValue(EBookingStatus.Active)
            .IsRequired();

        builder.Property(x => x.PickupDeadline)
            .IsRequired();
    }
}
