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
            Email = user.Email,
            Password = user.Password,
            Role = user.Role,
        };
    }

    public static User AsBase(this UserModel userModel)
    {
        return new User()
        {
            Id = userModel.Id,
            Username = userModel.Username,
            Email = userModel.Email,
            Password = userModel.Password,
            Role = userModel.Role,
        };
    }
}