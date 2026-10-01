namespace Unova.Infrastructure.Configurations;

public class BookingConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.ToTable("asp_Bookings");

        builder.HasKey(x => x.ID);

        builder.Property(x => x.StartTime)
            .IsRequired();

        builder.Property(x => x.Status)
            .IsRequired();

        builder.Property(x => x.PickupDeadline)
            .IsRequired();
    }
}
