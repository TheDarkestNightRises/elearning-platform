using Elearn.Application.LogicInterfaces;
using Elearn.Application.ServiceContracts;
using Elearn.Shared.Models;

namespace Elearn.Application.Logic;

public class UserLogic : IUserLogic
{

    private readonly IUserService _userService;

    public UserLogic(IUserService userService)
    {
        _userService = userService;
    }
    
    public async Task ChangePasswordAsync(long id, string password)
    {
        User? existing = await _userService.GetUserByIdAsync((int)id);
        if (existing == null)
        {
            throw new Exception($"User with id {id} was not found.");
        }

        string username = existing.Username;
        string name = existing.Name;
        string email = existing.Email;
        string role = existing.Role;
        int securityLevel = existing.SecurityLevel;
        string newPassword = password;
        
        User updated = new (username,newPassword,email,name,role,securityLevel)
        { 
            Id = id,
           Username = username,
           Password = newPassword,
           Email = email,
           Name = name,
           Role = role,
           SecurityLevel = securityLevel
        };
        
        await _userService.ChangePasswordAsync(updated);
    }
}