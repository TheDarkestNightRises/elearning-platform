using Elearn.Shared.Models;
using ElearnGrpc;

namespace Elearn.GrpcService.Extensions;

public static class GrpcUniversityExtension
{
    public static UniversityModel AsGrpcModel(this University user)
    {
        return new UniversityModel()
        {
            Id = user.Id,
            Name = user.Name,
        };
    }

    public static University AsBase(this UniversityModel userModel)
    {
        return new University()
        {
            Id = userModel.Id,
            Name = userModel.Name,
        };
    }
}