using Elearn.Shared.Dtos;
using Elearn.Shared.Models;

namespace Shared.Extensions;

public static class DtoUniversityExtensions
{
    public static UniversityDto AsDto(this University university) 
    {
        return new UniversityDto()
        {
            Id = university.Id,
            Name = university.Name
        };
    }

    public static IEnumerable<UniversityDto> AsDtos(this IEnumerable<University> universities)
    {
        var universityDtos = (from university in universities 
            select new UniversityDto 
            {
                Id = university.Id,
                Name = university.Name
            });
        return universityDtos;                
    }
}