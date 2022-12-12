using Elearn.Application.LogicInterfaces;
using Elearn.Shared.Dtos;
using Elearn.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Shared.Extensions;

namespace Elearn.WebAPI.Controllers;


[ApiController]
[Route("[controller]")]

public class AnswersController : ControllerBase
{
    private readonly IAnswerLogic answerLogic;

    public AnswersController(IAnswerLogic answerLogic)
    {
        this.answerLogic = answerLogic;
    }
    
    [HttpPost]
    public async Task<ActionResult<AnswerDto>> CreateAsync([FromBody] AnswerCreationDto dto)
    {
        try
        {
            Answer answer = dto.AsBaseFromCreation();
            Answer created = await answerLogic.CreateAsync(answer);
            AnswerDto createdDto = created.AsDto();
            
            return Created($"/Answers/{created.Question.Url}", createdDto);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAsync([FromRoute] long id)
    {
        try
        {
            await answerLogic.DeleteAnswerAsync(id);
            return NoContent();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet ,Route("/Answers/Question/{id}")]
    public async Task<ActionResult<List<AnswerUserDto>>> GetAllAnswersByLectureId(long id)
    {
        try
        {
            var answers = await answerLogic.GetAllAnswersByQuestionId(id);
            return Ok(answers.AsDtos());
        }
        catch (Exception e)
        {
            Console.WriteLine(e); 
            return StatusCode(500, e.Message);
        }
    }
}