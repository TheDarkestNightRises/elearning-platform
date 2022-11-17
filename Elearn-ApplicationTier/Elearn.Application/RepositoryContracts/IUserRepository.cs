using Elearn.Shared.Models;

namespace Elearn.Application.RepositoryContracts;

public interface IUserRepository
{
    Task<User?> GetUserByNameAsync(string name);
    Task<User> CreateNewUserAsync(User user);
    public Task<User?> GetUserByIdAsync(int id);
}
