using Elearn.Application.ServiceContracts;
using Elearn.Shared.Models;

namespace Elearn.GrpcService.Client;

public class UserGrpcClient : IUserService
{
    public Task<User?> GetUserByNameAsync(string name)
    {
        throw new NotImplementedException();
    }

    public Task<User> CreateNewUserAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetUserByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}