using Elearn.Shared.Models;

namespace Elearn.Application.RepositoryInterfaces;

public interface IUserRepository
{
    Task<User?> GetUserByNameAsync(string name);
}