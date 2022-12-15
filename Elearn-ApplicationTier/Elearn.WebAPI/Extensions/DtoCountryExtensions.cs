using Elearn.Shared.Dtos;
using Elearn.Shared.Models;

namespace Shared.Extensions;

public static class DtoCountryExtensions
{
    public static CountryDto AsDto(this Country country) 
    {
        return new CountryDto()
        {
            Id = country.Id,
            Name = country.Name,
        };
    }

    public static IEnumerable<CountryDto> AsDtos(this IEnumerable<Country> countries)
    {
        var countryDtos = (from country in countries 
            select new CountryDto
            {
                Id = country.Id,
                Name = country.Name,
            });
        return countryDtos;                
    }
}