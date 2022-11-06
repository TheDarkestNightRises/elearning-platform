
using Elearn.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Elearn.Data.Data;

public class DataContext : DbContext
{
    public string CONNECTION { get; set; } = "Data Source=..\\Elearn.Data\\elearn.db";
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(CONNECTION);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Post>()
            .HasOne(p => p.Author)
            .WithMany();
        modelBuilder.Entity<Comment>()
            .HasOne(c => c.Post)
            .WithMany();
        modelBuilder.Entity<Post>()
            .HasIndex(p => p.Url)
            .IsUnique();
        Database.Migrate();
        
     
    }
    
    public DbSet<Post> Posts { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Comment> Comments { get; set; }
}