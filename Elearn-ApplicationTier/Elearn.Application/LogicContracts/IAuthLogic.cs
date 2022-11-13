using Elearn.Shared.Dtos;
using Elearn.Shared.Models;

namespace Elearn.Application.LogicInterfaces;

public interface IAuthLogic
{
    Task<User> GetUserAsync(string username, string password);
    Task<User> RegisterUserAsync(UserCreationDto dto);

    Task<User> ValidateUserAsync(string username, string password);
}