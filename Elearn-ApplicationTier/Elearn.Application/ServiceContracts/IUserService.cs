using Elearn.Shared.Models;

namespace Elearn.Application.ServiceContracts;

public interface IUserService
{
    Task<User?> GetUserByNameAsync(string name);
    Task<User> CreateNewUserAsync(User user);
    public Task<User?> GetUserByIdAsync(int id);
}
