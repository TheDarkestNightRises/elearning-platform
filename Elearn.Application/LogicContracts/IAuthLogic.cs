using Elearn.Shared.Models;

namespace Elearn.Application.LogicInterfaces;

public interface IAuthLogic
{
    Task<User> GetUser(string username, string password);
    Task RegisterUser(User user);

}