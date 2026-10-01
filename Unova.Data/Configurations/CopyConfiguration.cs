namespace Unova.Infrastructure.Configurations;

public class CopyConfiguration : IEntityTypeConfiguration<Copy>
{
    public void Configure(EntityTypeBuilder<Copy> builder)
    {
        builder.ToTable("asp_Copies");

        builder.HasKey(x => x.ID);

        builder.Property(x => x.Code)
            .HasMaxLength(50)
            .IsRequired();
    }
}
