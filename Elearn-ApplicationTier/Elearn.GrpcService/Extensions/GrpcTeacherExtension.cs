using Elearn.Shared.Models;
using ElearnGrpc;

namespace Elearn.GrpcService.Extensions;

public static class GrpcTeacherExtension
{
    public static TeacherModel AsGrpcModel(this Teacher user)
    {
        return new TeacherModel()
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

    public static Teacher AsBase(this TeacherModel teacherModel)
    {
        return new Teacher()
        {
            Id = teacherModel.Id,
            Username = teacherModel.Username,
            Name = teacherModel.Name,
            Email = teacherModel.Email,
            Password = teacherModel.Password,
            Role = teacherModel.Role,
            SecurityLevel = teacherModel.SecurityLevel,
            Approved = teacherModel.Approved
        };
    }
}