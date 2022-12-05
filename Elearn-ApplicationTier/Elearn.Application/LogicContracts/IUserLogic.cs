using Elearn.Shared.Dtos;
using Elearn.Shared.Models;

namespace Elearn.Application.LogicInterfaces;

public interface IUserLogic
{
    Task<User> UpdateUserAsync(UpdateUserDto dto); //TODO:USER
    Task<User?> GetUserByUsernameAsync(string username);
    Task DeleteUserAsync(string username);
    Task<List<User>> GetAllUsersAsync();

}