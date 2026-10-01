using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Unova.Infrastructure;

public class UnovaDbContext : IdentityDbContext<User, IdentityRole<int>, int>
{
    #region NEW
    public UnovaDbContext(DbContextOptions<UnovaDbContext> options) : base(options) { }
    #endregion

    #region DBSETS
    public DbSet<Book> Books => Set<Book>();
    public DbSet<Author> Authors => Set<Author>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Location> Locations => Set<Location>();
    public DbSet<Booking> Bookings => Set<Booking>();
    public DbSet<Enterprise> Libraries => Set<Enterprise>();
    public DbSet<Center> Centers => Set<Center>();
    public DbSet<Address> Addresses => Set<Address>();
    public DbSet<Copy> Copies => Set<Copy>();
    #endregion

    #region OnModelCreating
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        #region Entity Configurations
        builder.ApplyConfigurationsFromAssembly(typeof(UnovaDbContext).Assembly);
        #endregion
    }
    #endregion
}
