using Business.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Business.Model.Data;

public class ArtBookingDbContext : DbContext
{
    public ArtBookingDbContext(DbContextOptions<ArtBookingDbContext> options) : base(options)
    {

    }

    public DbSet<User> Users { get; set; }
    public DbSet<ArtOrganization> ArtOrganizations { get; set; }
    public DbSet<ArtEvent> ArtEvents { get; set; }
    public DbSet<PriceList> PriceLists { get; set; }
    public DbSet<Venue> Venues { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>().HasKey(u => u.UserId);
        modelBuilder.Entity<ArtOrganization>().HasKey(o => o.ArtOrganizationId);
        modelBuilder.Entity<ArtEvent>()
        .HasOne(a => a.PriceList)
        .WithOne(p => p.ArtEvent)
        .HasForeignKey<PriceList>(p => p.PriceListId);
        modelBuilder.Entity<PriceList>()
        .HasOne(p => p.ArtEvent)
        .WithOne(v => v.PriceList)
        .HasForeignKey<PriceList>(p => p.ArtEventId);
        modelBuilder.Entity<PriceList>()
        .HasOne(p => p.Venue)
        .WithOne(v => v.PriceList)
        .HasForeignKey<PriceList>(p => p.VenueId);
        modelBuilder.Entity<Venue>().HasKey(v => v.VenueId);
    }
}