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
        Database.Migrate();
    }
    
    public DbSet<Post> Posts { get; set; }
}