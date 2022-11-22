using Elearn.Application.LogicInterfaces;
using Elearn.Shared.Dtos;
using Elearn.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Shared.Extensions;


namespace Elearn.WebAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class LecturesController : ControllerBase
{
    private readonly ILectureLogic _lectureLogic;

    public LecturesController(ILectureLogic lectureLogic)
    {
        this._lectureLogic = lectureLogic;
    }
    
    [HttpPost]
    public async Task<ActionResult<LectureDto>> CreateAsync([FromBody] LectureCreationDto dto)
    {
        try
        {
            Lecture created = await _lectureLogic.CreateAsync(dto);
            PostDto createdDto = PostExtensions.AsDto(created);
            return Created($"/lectures/{createdDto.Url}", createdDto);// ???
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet]
    public async Task<ActionResult<List<LectureDto>>> GetAllLecturesAsync()
    {
        try
        {
            var posts = await _lectureLogic.GetAllLecturesAsync();
            return Ok(posts);
        }
        catch (Exception e)
        {
            Console.WriteLine(e); 
            return StatusCode(500, e.Message);
        }
   
    }

    [HttpGet("{url}")]
    public async Task<ActionResult<LectureDto>> GetLectureAsync(string url)
    {
        try
        {
            var lecture = await _lectureLogic.GetLectureAsync(url);
            if (lecture is null)
            {
                return NotFound("This lecture does not exist");
            }
            return Ok(lecture);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}