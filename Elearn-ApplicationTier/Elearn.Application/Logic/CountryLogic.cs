using Elearn.Application.LogicInterfaces;
using Elearn.Application.ServiceContracts;
using Elearn.Shared.Models;

namespace Elearn.Application.Logic;

public class CountryLogic : ICountryLogic
{
    private readonly ICountryService _countryService;

    public CountryLogic(ICountryService countryService)
    {
        _countryService = countryService;
    }
    
    public async Task<List<Country>> GetAllCountriesAsync()
    {
        return await _countryService.GetAllCountriesAsync();
    }

    public async Task<Country> GetCountryByIdAsync(long id)
    {
        Country country = await _countryService.GetCountryByIdAsync(id);
        if (country is null)
        {
            throw new Exception("No country found with this id");
        }

        return country;
    }
}