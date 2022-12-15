using Elearn.Application.LogicInterfaces;
using Elearn.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;
using Shared.Extensions;

namespace Elearn.WebAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class UniversitiesController : ControllerBase
{
    private readonly IUniversityLogic _universityLogic;

    public UniversitiesController(IUniversityLogic universityLogic)
    {
        _universityLogic = universityLogic;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<UniversityDto>>> GetAllUniversitiesAsync()
    {
        try
        {
            var universities = await _universityLogic.GetAllUniversitiesAsync();
            return Ok(universities.AsDtos());
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
            var universities = await _universityLogic.GetUniversitybyIdAsync(id);
            return Ok(universities.AsDto());
        }
        catch (Exception e)
        {
            Console.WriteLine(e); 
            return StatusCode(500, e.Message);
        }
    
    }
}