using Common.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Common.Persistance;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Character>  Characters { get; set; }
    public DbSet<Epoch> Epochs { get; set; }
    public DbSet<Pathway> Pathways { get; set; }
    public DbSet<Sequence> Sequences { get; set; }
    public DbSet<Ability> Abilities { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseLazyLoadingProxies()
            .UseNpgsql("Host=localhost;Port=5432;Database=LOTMWikiDb;Username=postgres;Password=mrusnamishka");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region User
        modelBuilder.Entity<User>()
            .HasKey(u => u.Id);

        modelBuilder.Entity<User>()
            .HasData(new User
            {
                Id = 1,
                Firstname = "Admin",
                Lastname = "Istrator",
                Username = "admin",
                Password = "adminpass",
                Age = 25
            });
        #endregion
        
        #region Character
        modelBuilder.Entity<Character>()
            .HasKey(c => c.Id);
        
        modelBuilder.Entity<Character>()
            .HasOne(c => c.Epoch)
            .WithMany()
            .HasForeignKey(c => c.EpochId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<Character>()
            .HasOne(c => c.Pathway)
            .WithMany()
            .HasForeignKey(c => c.PathwayId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<Character>()
            .HasOne(c => c.Sequence)
            .WithMany()
            .HasForeignKey(c => c.SequenceId)
            .OnDelete(DeleteBehavior.Restrict);
        #endregion
        
        #region Epoch
        modelBuilder.Entity<Epoch>()
            .HasKey(e => e.Id);
        #endregion
        
        #region Pathway
        modelBuilder.Entity<Pathway>()
            .HasKey(p => p.Id);
        #endregion
        
        #region Sequence
        modelBuilder.Entity<Sequence>()
            .HasKey(s => s.Id);
        
        modelBuilder.Entity<Sequence>()
            .HasOne(s => s.Pathway)
            .WithMany()
            .HasForeignKey(s => s.PathwayId)
            .OnDelete(DeleteBehavior.Restrict);
        #endregion
        
        #region Ability
        modelBuilder.Entity<Ability>()
            .HasKey(a => a.Id);
        
        modelBuilder.Entity<Ability>()
            .HasOne(a => a.Sequence)
            .WithMany()
            .HasForeignKey(a => a.SequenceId)
            .OnDelete(DeleteBehavior.Restrict);
        #endregion
    }
}
