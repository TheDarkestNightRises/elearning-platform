using Elearn.Shared.Models;
using ElearnGrpc;

namespace Elearn.GrpcService.Extensions;

public static class GrpcUniversityExtension
{
    public static UniversityModel AsGrpcModel(this University university)
    {
        return new UniversityModel()
        {
            Id = university.Id,
            Name = university.Name,
            Description = university.Description
        };
    }

    public static University AsBase(this UniversityModel universityModel)
    {
        return new University()
        {
            Id = universityModel.Id,
            Name = universityModel.Name,
            Description = universityModel.Description
        };
    }
}