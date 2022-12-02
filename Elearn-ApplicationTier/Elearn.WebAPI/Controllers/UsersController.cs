using Elearn.Application.LogicInterfaces;
using Elearn.Shared.Dtos;
using Elearn.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace Elearn.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController:ControllerBase
{
    private readonly IUserLogic userLogic;

    public UsersController(IUserLogic userLogic)
    {
        this.userLogic = userLogic;
    }
    
    [HttpPatch]
    public async Task<ActionResult> UpdateUserAsync([FromBody] UpdateUserDto dto)
    {
        try
        {
            await userLogic.UpdateUserAsync(dto);
            return NoContent();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet("{username}")]
    public async Task<ActionResult<User>> GetUserAsync(string username)
    {
        try
        {
            var user = await userLogic.GetUserByUsernameAsync(username);
            return Ok(user);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpDelete("{username}")]
    public async Task<ActionResult> DeleteAsync([FromRoute] string username)
    {
        try
        {
            await userLogic.DeleteUserAsync(username);
            return NoContent();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}