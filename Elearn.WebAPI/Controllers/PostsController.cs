using Elearn.Application.LogicInterfaces;
using Microsoft.AspNetCore.Mvc;
using Shared;
using Shared.Extensions;
using Shared.Models;

namespace Elearn.WebAPI.Controllers;
[ApiController]
[Route("posts")]
public class PostsController : ControllerBase
{
    private readonly IPostLogic postLogic;

    public PostsController(IPostLogic postLogic)
    {
        this.postLogic = postLogic;
    }
    
    [HttpPost]
    public async Task<ActionResult<PostDto>> CreateAsync([FromBody] PostCreationDto dto)
    {
        try
        {
            Post created = await postLogic.CreateAsync(PostExtensions.AsBaseFromCreation(dto));
            PostDto createdDto = PostExtensions.AsDto(created);
            return Created($"/posts/{createdDto.Url}", createdDto);// ???
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}