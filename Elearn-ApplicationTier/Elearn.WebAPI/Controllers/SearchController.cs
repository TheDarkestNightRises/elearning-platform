using Elearn.Application.LogicInterfaces;
using Elearn.Shared.Dtos;
using Elearn.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Shared.Extensions;

namespace Elearn.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class SearchController : ControllerBase
{
    private readonly ISearchLogic _searchLogic;

    public SearchController(ISearchLogic searchLogic)
    {
        _searchLogic = searchLogic;
    }

    /*[HttpGet("/user/{name}")]
    public async Task<ActionResult<List<UserDto>>> SearchUsers(string name)
    {
        try
        {
            var result = await _searchLogic.SearchUsersAsync(name);
            return Ok(result.AsDtos());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }
        
    }*/

    [HttpGet, Route("question/{title}")]
    public async Task<ActionResult<List<QuestionDto>>> SearchQuestions(string title)
    {
        try
        {
            var result = await _searchLogic.SearchQuestionsAsync(title);
            return Ok(result.AsDtos());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }
    }

    [HttpGet, Route("lecture/{title}")]
    public async Task<ActionResult<List<LectureDto>>> SearchLecture(string title)
    {
        try
        {
            var result = await _searchLogic.SearchLecturesAsync(title);
            return Ok(result.AsDtos());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }
    }
}