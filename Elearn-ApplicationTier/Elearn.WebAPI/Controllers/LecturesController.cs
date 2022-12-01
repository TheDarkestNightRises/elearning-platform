using Elearn.Application.LogicInterfaces;
using Elearn.Shared.Dtos;
using Elearn.Shared.Models;
using ElearnGrpc;
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
            Lecture lecture = dto.AsBaseFromCreation();
            Lecture created = await _lectureLogic.CreateAsync(lecture);
            LectureDto createdDto = created.AsDto();
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
            var lectures = await _lectureLogic.GetAllLecturesAsync();
            return Ok(lectures.AsDtos());
        }
        catch (Exception e)
        {
            Console.WriteLine(e); 
            return StatusCode(500, e.Message);
        }
   
    }

    [HttpGet("/get-lecture/{url}")]
    public async Task<ActionResult<LectureDto>> GetLectureAsync(string url)
    {
        try
        {
            var lecture = await _lectureLogic.GetLectureAsync(url);
            if (lecture is null)
            {
                return NotFound("This lecture does not exist");
            }
            return Ok(lecture.AsDto());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet("/user-lecture/{userId}")]
    public async Task<ActionResult<List<LectureDto>>> GetLectureByUserIdAsync(long userId)
    {
        try
        {   
            
            var lectures = await _lectureLogic.GetLectureByUserIdAsync(userId);
            return Ok(lectures.AsDtos());
        }
        catch (Exception e)
        {
            Console.WriteLine(e); 
            return StatusCode(500, e.Message);
        }
   
    }
    
    [HttpGet("/upvote-lecture/{userId}")]
    public async Task<ActionResult<List<LectureDto>>> GetUpvotedLectureByUserIdAsync(long userId)
    {
        try
        {
            var lectures = await _lectureLogic.GetUpvotedLectureByUserIdAsync( userId);
            return Ok(lectures.AsDtos());
        }
        catch (Exception e)
        {
            Console.WriteLine(e); 
            return StatusCode(500, e.Message);
        }
   
    }
    
    [HttpGet("/university-lectures/{universityId}")]
    public async Task<ActionResult<List<LectureDto>>> GetLectureByUniversityAsync(long universityId)
    {
        try
        {
            University university = new University()
            {
                Id = universityId
            };
            var lectures = await _lectureLogic.GetLecturesByUniversityAsync(university);
            return Ok(lectures.AsDtos());
        }
        catch (Exception e)
        {
            Console.WriteLine(e); 
            return StatusCode(500, e.Message);
        }
   
    }

}