using Elearn.Shared.Models;
using ElearnGrpc;

namespace Elearn.GrpcService.Extensions;

public static class GrpcUserExtension
{
    public static UserModel AsGrpcModel(this User user)
    {
        return new UserModel()
        {
            Id = user.Id,
            Username = user.Username,
            Name = user.Name,
            Email = user.Email,
            Password = user.Password,
            Role = user.Role,
            SecurityLevel = user.SecurityLevel 
        };
    }

    public static User AsBase(this UserModel userModel)
    {
        return new User()
        {
            Id = userModel.Id,
            Username = userModel.Username,
            Name = userModel.Name,
            Email = userModel.Email,
            Password = userModel.Password,
            Role = userModel.Role,
            SecurityLevel = userModel.SecurityLevel
        };
    }
}