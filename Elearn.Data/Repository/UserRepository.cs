using Elearn.Application.RepositoryContracts;
using Elearn.Data.Data;
using Elearn.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Elearn.Data.Repository;

public class UserRepository : IUserRepository
{
    private DataContext _dataContext;

    public UserRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<User?> GetUserByNameAsync(string name)
    {
        return await _dataContext.Users.FirstOrDefaultAsync(u =>
            u.Username.Equals(name));
    }

    public async Task<User> CreateNewUserAsync(User user)
    {
        await _dataContext.AddAsync(user);
        await _dataContext.SaveChangesAsync();
        return user;
    }
    
    public async Task<User?> GetUserByIdAsync(int id)
    {
        return await _dataContext.Users.FirstOrDefaultAsync(u =>
            u.UserId.Equals(id));
    }
}