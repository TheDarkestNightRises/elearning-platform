using Elearn.Application.LogicInterfaces;
using Elearn.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;
using Shared.Extensions;

namespace Elearn.WebAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class CountriesController : ControllerBase
{
    private ICountryLogic _countryLogic;

    public CountriesController(ICountryLogic countryLogic)
    {
        _countryLogic = countryLogic;
    }
    [HttpGet]
    public async Task<ActionResult<List<CountryDto>>> GetAllCountriesAsync()
    {
        try
        {
            var countries = await _countryLogic.GetAllCountriesAsync();
            return Ok(countries.AsDtos());
        }
        catch (Exception e)
        {
            Console.WriteLine(e); 
            return StatusCode(500, e.Message);
        }
    
    }
    [HttpGet("{id:long}")]
    public async Task<ActionResult<UniversityDto>> GetUniversityByIdAsync(long id)
    {
        try
        {
            var country = await _countryLogic.GetCountryByIdAsync(id);
            return Ok(country.AsDto());
        }
        catch (Exception e)
        {
            Console.WriteLine(e); 
            return StatusCode(500, e.Message);
        }
    
    }
}