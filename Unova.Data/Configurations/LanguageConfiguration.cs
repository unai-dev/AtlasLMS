namespace Unova.Infrastructure.Configurations;

public class LanguageConfiguration : IEntityTypeConfiguration<Language>
{
    public void Configure(EntityTypeBuilder<Language> builder)
    {
        builder.ToTable("asp_Languages");

        builder.HasKey(x => x.ID);

        builder.Property(x => x.Iso639Code)
            .HasMaxLength(5)
            .IsRequired();

        builder.Property(x => x.Name)
            .HasMaxLength(55)
            .IsRequired();

        builder.HasData(
            new Language { ID = 1, Iso639Code = "ES", Name = "Español", CreatedAt = DateTime.MinValue },
            new Language { ID = 2, Iso639Code = "EN", Name = "English", CreatedAt = DateTime.MinValue },
            new Language { ID = 3, Iso639Code = "EU", Name = "Euskera", CreatedAt = DateTime.MinValue },
            new Language { ID = 4, Iso639Code = "FR", Name = "Français", CreatedAt = DateTime.MinValue }
        );
    }
}
