using Elearn.Application.Logic;
using Elearn.Application.LogicInterfaces;
using Elearn.Shared.Dtos;
using Elearn.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Shared.Extensions;

namespace Elearn.WebAPI.Controllers;
[ApiController]
[Route("questions")]

public class QuestionController : ControllerBase
{
    private readonly IQuestionLogic questionLogic;

    public QuestionController(IQuestionLogic questionLogic)
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
            return Created($"/posts/{createdDto.Url}", createdDto);
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
    public async Task<ActionResult<QuestionDto>> GetAllQuestionsAsync()
    {
        try
        {
            var questions = await questionLogic.GetQuestionsAsync();
            return Ok(questions.AsDtos());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}