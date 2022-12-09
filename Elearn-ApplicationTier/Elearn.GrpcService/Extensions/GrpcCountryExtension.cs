using Elearn.Shared.Models;

namespace Elearn.GrpcService.Extensions;

public static class GrpcCountryExtension
{
    public static CountryModel AsGrpcModel(this Country university)
    {
        return new CountryModel()
        {
            Id = university.Id,
            Name = university.Name,
        };
    }

    public static Country AsBase(this CountryModel universityModel)
    {
        return new Country()
        {
            Id = universityModel.Id,
            Name = universityModel.Name,
        };
    }
}