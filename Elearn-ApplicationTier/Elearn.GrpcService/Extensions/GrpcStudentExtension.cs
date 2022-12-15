using Elearn.Shared.Models;
using ElearnGrpc;

namespace Elearn.GrpcService.Extensions;

public static class GrpcStudentExtension
{
    public static StudentModel AsGrpcModel(this Student student)
    {
        return new StudentModel()
        {
            Id = student.Id,
            Username = student.Username,
            Name = student.Name,
            Email = student.Email,
            Password = student.Password,
            Image = student.Image,
            Role = student.Role,
            SecurityLevel = student.SecurityLevel,
            Approved = student.Approved
        };
    }

    public static Student AsBase(this StudentModel studentModel)
    {
        return new Student()
        {
            Id = studentModel.Id,
            Username = studentModel.Username,
            Name = studentModel.Name,
            Email = studentModel.Email,
            Password = studentModel.Password,
            Image = studentModel.Image,
            Role = studentModel.Role,
            SecurityLevel = studentModel.SecurityLevel,
            Approved = studentModel.Approved
        };
    }
}