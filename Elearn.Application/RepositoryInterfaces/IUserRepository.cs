using Elearn.Shared.Models;

namespace Elearn.Application.RepositoryInterfaces;

public interface IUserRepository
{
    Task<User?> GetUserByNameAsync(string name);
    Task<User> CreateNewUserAsync(User user);
    public Task<User?> GetUserByIdAsync(int id);
}
