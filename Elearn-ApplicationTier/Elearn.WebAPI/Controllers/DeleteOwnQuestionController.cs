using Elearn.Application.LogicInterfaces;
using Elearn.Shared.Dtos;
using Elearn.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace Elearn.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]

public class DeleteOwnQuestionController : ControllerBase
{
    private readonly IDeleteOwnQuestionLogic _deleteOwnQuestionLogic;
    
    public DeleteOwnQuestionController(IDeleteOwnQuestionLogic deleteOwnQuestionLogic)
    {
        this._deleteOwnQuestionLogic = deleteOwnQuestionLogic;
    }
    [HttpDelete]
    public async Task<ActionResult<QuestionDto>> DeleteOwnQuestion([FromBody] DeleteOwnQuestionDto deleteOwnQuestionDto)
    {
        try
        {
            var result = await _deleteOwnQuestionLogic.DeleteOwnQuestion(deleteOwnQuestionDto);
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
