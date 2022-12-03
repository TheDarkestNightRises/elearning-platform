using Elearn.Application.Logic;
using Elearn.Application.LogicInterfaces;
using Elearn.Shared.Dtos;
using Elearn.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Shared.Extensions;

namespace Elearn.WebAPI.Controllers;
[ApiController]
[Route("[controller]")]

public class QuestionsController : ControllerBase
{
    private readonly IQuestionLogic questionLogic;

    public QuestionsController(IQuestionLogic questionLogic)
    {
        this.questionLogic = questionLogic;
    }
    
    [HttpPost]
    public async Task<ActionResult<QuestionDto>> CreateAsync([FromBody] QuestionCreationDto dto)
    {
        try
        {
            var created = await questionLogic.CreateQuestionAsync(dto.AsBaseFromCreation());
            var createdDto = created.AsDto();
            return Created($"/Questions/{createdDto.Url}", createdDto);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet("{url}")]
    public async Task<ActionResult<QuestionDto>> GetQuestionAsync(string url)
    {
        try
        {
            var question = await questionLogic.GetQuestionByUrlAsync(url);
            return Ok(question.AsDto());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult<QuestionDto>> GetAllQuestionsAsync([FromQuery] PaginationDto paginationDto)
    {
        try
        {
            var questions = await questionLogic.GetQuestionsAsync(paginationDto.PageNumber,paginationDto.PageSize);
            HttpContext.AddPaginationHeader(questions, paginationDto.PageSize);
            return Ok(questions.AsDtos());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet, Route("/Users/{userId}/questions")]
    public async Task<ActionResult<List<QuestionDto>>> GetQuestionByUserIdAsync(long userId)
    {
        try
        {

            var questions = await questionLogic.GetQuestionByUserIdAsync(userId);
            return Ok(questions.AsDtos());
        }
        catch (Exception e)
        {
            Console.WriteLine(e); 
            return StatusCode(500, e.Message);
        }
    }
}