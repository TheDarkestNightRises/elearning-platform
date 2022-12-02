using Elearn.Application.LogicInterfaces;
using Elearn.Shared.Dtos;
using Elearn.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Shared.Extensions;

namespace Elearn.WebAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class LectureVotesController : ControllerBase
{
    private readonly ILectureVoteLogic _lectureVoteLogic;
    private readonly ILectureLogic _lectureLogic;
    private readonly IUserLogic _userLogic;

    public LectureVotesController(ILectureVoteLogic lectureVoteLogic, ILectureLogic lectureLogic, IUserLogic userLogic)
    {
        _lectureVoteLogic = lectureVoteLogic;
        _lectureLogic = lectureLogic;
        _userLogic = userLogic;
    }

    [HttpPost]
    public async Task<ActionResult<LectureVoteDto>> CreateAsync([FromBody] LectureVoteDto dto)
    {
        try
        {
            var lecture = dto.AsBase();
            var createdVote = await _lectureVoteLogic.CreateLectureVoteAsync(lecture);
            var createdVoteDto = createdVote.AsDto();
            return Created($"/Lecturevotes/{createdVoteDto.LectureUrl}", createdVoteDto);// ???
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult<LectureVoteDto>> GetLectureVoteAsync([FromQuery] string username, [FromQuery] string url)
    {
        try
        {
            var lectureVote = await _lectureVoteLogic.GetLectureVotebyIdAsync(username, url);
            return Ok(lectureVote.AsDto());
        }
        catch (Exception e)
        {
            Console.WriteLine(e); 
            return StatusCode(500, e.Message);
        }
   
    }

    [HttpGet("{url}")]
    public async Task<ActionResult<LectureVoteCounterDto>> GetLectureVoteCounterAsync(string url)
    {
        try
        {
            var lecture = await _lectureLogic.GetLectureAsync(url);
            var lectureVoteCounter = await _lectureVoteLogic.GetLectureVotesCountAsync(lecture);
            return Ok(lectureVoteCounter.AsLectureVoteCounterDto());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}