using Elearn.Application.LogicInterfaces;
using Elearn.Shared.Dtos;
using Elearn.Shared.Models;
using Microsoft.AspNetCore.Mvc;


namespace Elearn.WebAPI.Controllers;

[ApiController]
[Route("comments")]

public class CommentsController : ControllerBase
{
    private readonly ICommentLogic commentLogic;

    public CommentsController(ICommentLogic commentLogic)
    {
        this.commentLogic = commentLogic;
    }

    [HttpPost]
    public async Task<ActionResult<Comment>> CreateAsync([FromBody] CommentCreationDto dto)
    {
        try
        {
            Comment created = await commentLogic.CreateAsync(dto);
            return Created($"/comments/{created.Lecture.Url}", created);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet("{url}")]
    public  Task<ActionResult<List<Comment>>> GetAllCommentsByPostUrlAsync(string url)
    {
        try
        {
            var comments =  commentLogic.GetAllCommentsByPostUrlAsync(url);
            return Task.FromResult<ActionResult<List<Comment>>>(Ok(comments));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return Task.FromResult<ActionResult<List<Comment>>>(StatusCode(500, e.Message));
        }
    }
}
