using Microsoft.EntityFrameworkCore;

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
    
    
}