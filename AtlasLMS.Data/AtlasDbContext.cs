using AtlasLMS.Data.Configurations;
using AtlasLMS.Domain.Entities;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AtlasLMS.Data;

public class AtlasDbContext : IdentityDbContext<User, IdentityRole<int>, int>
{
    #region NEW
    public AtlasDbContext(DbContextOptions<AtlasDbContext> options) : base(options) { }
    #endregion

    #region DBSETS
    public DbSet<Book> Books => Set<Book>();
    public DbSet<Author> Authors => Set<Author>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Location> Locations => Set<Location>();
    public DbSet<Booking> Bookings => Set<Booking>();
    public DbSet<Library> Libraries => Set<Library>();
    public DbSet<Center> Centers => Set<Center>();
    public DbSet<Address> Addresses => Set<Address>();
    #endregion

    #region OnModelCreating
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        #region Entity Configurations
        builder.ApplyConfiguration(new BookConfiguration());
        builder.ApplyConfiguration(new AuthorConfiguration());
        builder.ApplyConfiguration(new CategoryConfiguration());
        builder.ApplyConfiguration(new LocationConfiguration());
        builder.ApplyConfiguration(new BookingConfiguration());
        builder.ApplyConfiguration(new LibraryConfiguration());
        builder.ApplyConfiguration(new CenterConfiguration());
        builder.ApplyConfiguration(new AddressConfiguration());
        #endregion
    }
    #endregion
}
