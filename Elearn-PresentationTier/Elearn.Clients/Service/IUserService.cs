using Elearn.Shared.Dtos;
using Elearn.Shared.Models;

namespace Elearn.HttpClients.Service;

public interface IUserService
{
    Task<UserDto> GetUserByUsernameAsync(string? username);
    
    Task UpdateUserAsync(UpdateUserDto dto);

    Task<List<UserDto>> GetUsersAsync();
    Task DeleteUserAsync(string username);
    Task<UserDto> GetUserByNameAsync(string? name);
}