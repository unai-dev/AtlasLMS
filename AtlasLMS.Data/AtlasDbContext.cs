using AtlasLMS.Data.Configurations;
using AtlasLMS.Domain.Entities;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AtlasLMS.Data;

public class AtlasDbContext : IdentityDbContext<User>
{
    public AtlasDbContext(DbContextOptions options) : base(options)
    {

    }
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Loan> Loans { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Booking> Bookings { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new BookConfiguration());
        builder.ApplyConfiguration(new AuthorConfiguration());
        builder.ApplyConfiguration(new CategoryConfiguration());
        builder.ApplyConfiguration(new LoanConfiguration());
        builder.ApplyConfiguration(new LocationConfiguration());
        builder.ApplyConfiguration(new BookingConfiguration());
    }

}
