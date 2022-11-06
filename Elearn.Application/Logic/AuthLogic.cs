using System.ComponentModel.DataAnnotations;
using Elearn.Application.LogicInterfaces;
using Elearn.Application.RepositoryInterfaces;
using Elearn.Shared.Dtos;
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

    public async Task<User> RegisterUserAsync(UserCreationDto dto)
    {
        if (string.IsNullOrEmpty(dto.Username))
        {
            throw new ValidationException("Username cannot be null");
        }
        if (string.IsNullOrEmpty(dto.Password))
        {
            throw new ValidationException("Password cannot be null");
        }
        if (string.IsNullOrEmpty(dto.Email))
        {
            throw new ValidationException("Email cannot be null");
        }
        if (string.IsNullOrEmpty(dto.Name))
        {
            throw new ValidationException("Name cannot be null");
        }
        User user = new User(dto.Username, dto.Password, dto.Email, dto.Name, dto.Role);
        User created = await _userRepository.CreateNewUserAsync(user);
        return created;
    }
}