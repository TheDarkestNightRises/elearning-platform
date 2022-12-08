using Elearn.Application.LogicInterfaces;
using Elearn.Shared.Dtos;
using Elearn.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Shared.Extensions;


namespace Elearn.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]

public class CommentsController : ControllerBase
{
    private readonly ICommentLogic commentLogic;

    public CommentsController(ICommentLogic commentLogic)
    {
        this.commentLogic = commentLogic;
    }

    [HttpPost]
    public async Task<ActionResult<CommentDto>> CreateAsync([FromBody] CommentCreationDto dto)
    {
        try
        {
            Comment comment = dto.AsBaseFromCreation();
            Comment created = await commentLogic.CreateAsync(comment);
            CommentDto createdDto = created.AsDto();
            
            return Created($"/Comments/{created.Lecture.Url}", createdDto);
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
            await commentLogic.DeleteCommentAsync(id);
            return NoContent();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet ,Route("/Comments/Lecture/{id}")]
    public async Task<ActionResult<List<CommentUserDto>>> GetAllCommentsByLectureId(long id)
    {
        try
        {
            var comments = await commentLogic.GetAllCommentsByLectureId(id);
            return Ok(comments.AsDtos());
        }
        catch (Exception e)
        {
            Console.WriteLine(e); 
            return StatusCode(500, e.Message);
        }
    }
}
