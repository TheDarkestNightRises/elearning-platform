using Elearn.Shared.Dtos;
using Elearn.Shared.Models;

namespace Elearn.Application.LogicInterfaces;

public interface IUserLogic
{
    Task<User> UpdateUserAsync(UpdateUserDto dto);
    Task<User?> GetUserByUsernameAsync(string username);
}