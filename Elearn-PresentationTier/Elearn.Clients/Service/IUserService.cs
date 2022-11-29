using Elearn.Shared.Dtos;
using Elearn.Shared.Models;

namespace Elearn.HttpClients.Service;

public interface IUserService
{
    Task<User> GetUserByUsernameAsync(string? username);
    
    Task UpdateUserAsync(UpdateUserDto dto);
}