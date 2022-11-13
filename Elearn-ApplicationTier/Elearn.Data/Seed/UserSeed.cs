using Elearn.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Elearn.Data.Seed;

public class UserSeed
{
    private ModelBuilder _modelBuilder;

    public UserSeed(ModelBuilder modelBuilder)
    {
        _modelBuilder = modelBuilder;
    }

    public void CreateUsers()
    {
        _modelBuilder.Entity<User>().HasData(
            new User
            {
                UserId = 1,
                Email = "trmo@via.dk",
                Name = "Troels Mortensen",
                Password = "onetwo3FOUR",
                Role = "Teacher",
                Username = "trmo",
                SecurityLevel = 4
            });
        _modelBuilder.Entity<User>().HasData(
            new User
            {
                UserId = 2,
                Email = "jakob@gmail.com",
                Name = "Jakob Rasmussen",
                Password = "password",
                Role = "Student",
                Username = "jknr",
                SecurityLevel = 2
            });
    }
}