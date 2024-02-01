using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class AppDbContext : DbContext
{
    public AppDbContext()
    {
        this.Database.EnsureDeleted();
        this.Database.EnsureCreated();
    }
    public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
    {
        //this.Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    public DbSet<Film> Films { get; set; } = null!;
    public DbSet<Seance> Seances { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Data.sqlite;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Film>()
            .HasMany(c => c.Seances)
            .WithOne(e => e.Film)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Seance>()
        .HasOne(e => e.Film)
        .WithMany(c => c.Seances)
        .OnDelete(DeleteBehavior.Cascade);

    }
}
