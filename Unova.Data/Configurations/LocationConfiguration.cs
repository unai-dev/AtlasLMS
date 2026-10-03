namespace Unova.Infrastructure.Configurations;

public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.ToTable("asp_Locations");

        builder.HasKey(x => x.ID);

        builder.Property(x => x.Aisle)
            .IsRequired()
            .HasMaxLength(5);

        builder.Property(x => x.Shelf)
            .IsRequired()
            .HasMaxLength(5);

        builder.Property(x => x.Column)
            .IsRequired()
            .HasMaxLength(5);

        builder.Property(x => x.Limit)
            .HasDefaultValue(5);
    }
}
