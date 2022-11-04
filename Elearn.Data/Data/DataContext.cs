
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Elearn.Data.Data;

public class DataContext : DbContext
{
    public string CONNECTION { get; set; } = "Data Source=elearn.db";
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
        Database.Migrate();
        
     
    }
    
    public DbSet<Post> Posts { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Comment> Comments { get; set; }
}