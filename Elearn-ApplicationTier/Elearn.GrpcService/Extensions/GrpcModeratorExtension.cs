using Elearn.Shared.Models;

namespace Elearn.GrpcService.Extensions;

public static class GrpcModeratorExtension
{
    public static ModeratorModel AsGrpcModel(this Moderator user)
    {
        return new ModeratorModel()
        {
            Id = user.Id,
            Username = user.Username,
            Name = user.Name,
            Email = user.Email,
            Password = user.Password,
            Role = user.Role,
            SecurityLevel = user.SecurityLevel,
            Approved = user.Approved
        };
    }
    
    public static Moderator AsBase(this ModeratorModel moderatorModel)
    {
        return new Moderator()
        {
            Id = moderatorModel.Id,
            Username = moderatorModel.Username,
            Name = moderatorModel.Name,
            Email = moderatorModel.Email,
            Password = moderatorModel.Password,
            Role = moderatorModel.Role,
            SecurityLevel = moderatorModel.SecurityLevel,
            Approved = moderatorModel.Approved
        };
    }
}