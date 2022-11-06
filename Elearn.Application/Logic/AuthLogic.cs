using System.ComponentModel.DataAnnotations;
using Elearn.Application.LogicInterfaces;
using Elearn.Application.RepositoryInterfaces;
using Elearn.Shared.Models;

namespace Elearn.Application.Logic;

public class AuthLogic : IAuthLogic
{
    private readonly IUserRepository _userRepository;

    public AuthLogic(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> ValidateUserAsync(string username, string password)
    {
        User? existingUser = await _userRepository.GetUserByNameAsync(username);
        
        if (existingUser == null)
        {
            throw new Exception("User not found");
        }

        if (!existingUser.Password.Equals(password))
        {
            throw new Exception("Password mismatch");
        }

        return existingUser;
    }

    public async Task<User> GetUserAsync(string username, string password)
    {
        throw new NotImplementedException();
    }

    public async Task<User> RegisterUserAsync(User user)
    {
        if (string.IsNullOrEmpty(user.Username))
        {
            throw new ValidationException("Username cannot be null");
        }

        if (string.IsNullOrEmpty(user.Password))
        {
            throw new ValidationException("Password cannot be null");
        }

        return await _userRepository.CreateNewUserAsync(user);
    }
}