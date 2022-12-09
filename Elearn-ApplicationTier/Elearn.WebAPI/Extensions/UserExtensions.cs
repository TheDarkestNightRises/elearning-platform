using Elearn.Shared.Dtos;
using Elearn.Shared.Models;

namespace Shared.Extensions;

public static class UserExtensions
{
    public static UserDto AsDto(this User user) 
    {
        return new UserDto
        {
            Id = user.Id,
            Username = user.Username,
            Password = user.Password,
            Email = user.Email,
            Name = user.Name,
            Role = user.Role,
            Image = user.Image,
            SecurityLevel = user.SecurityLevel,
            UniversityId = user.University?.Id,
            CountryId = user.Country?.Id
        };
    }
    
    public static UserForCommentDto AsUserForCommentDto(this User user) 
    {
        return new UserForCommentDto
        {
         
            Username = user.Username,
            Name = user.Name,
            Image = user.Image,
         
            
        };
    }
    
    public static IEnumerable<UserDto> AsDtos(this IEnumerable<User> users)
    {
        var usersDtos = (from user in users 
            select new UserDto 
            {
                Id = user.Id,
                Username = user.Username,
                Password = user.Password,
                Email = user.Email,
                Name = user.Name,
                Role = user.Role,
                Image = user.Image,
                SecurityLevel = user.SecurityLevel,
                UniversityId = user.University?.Id,
                CountryId = user.Country?.Id
            });
        return usersDtos;                
    }
}