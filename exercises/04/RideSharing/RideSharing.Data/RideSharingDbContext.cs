using Microsoft.EntityFrameworkCore;
using RideSharing.Data.Entities;

namespace RideSharing.Data;

public class RideSharingDbContext : DbContext, IDbContext
{
    public RideSharingDbContext(DbContextOptions<RideSharingDbContext> options)
        : base(options)
    {
    }

    public DbSet<RideEntity> Rides => Set<RideEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<RideEntity>()
            .Property(c => c.CreatedOn)
            .HasDefaultValueSql("GETUTCDATE()");
    }
}
