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
    
    [HttpGet]
    public async Task<ActionResult<List<Post>>> GetAllPostsAsync()
    {
        try
        {
            var posts = await postLogic.GetAllPostsAsync();
            return Ok(posts);
        }
        catch (Exception e)
        {
            Console.WriteLine(e); 
            return StatusCode(500, e.Message);
        }
   
    }

    [HttpGet("{url}")]
    public async Task<ActionResult<Post>> GetBlogPostAsync(string url)
    {
        try
        {
            var post = await postLogic.GetPostAsync(url);
            if (post is null)
            {
                return NotFound("This post does not exist");
            }
            return Ok(post);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}