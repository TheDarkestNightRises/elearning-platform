using Elearn.Application.LogicInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Elearn.WebAPI.Controllers;

[ApiController]
[Route("user")]
public class UserController:ControllerBase
{
    private readonly IUserLogic userLogic;

    public UserController(IUserLogic userLogic)
    {
        this.userLogic = userLogic;
    }
    
    [HttpPatch("{id:int}")]
    public async Task<ActionResult> ChangePasswordAsync([FromBody] long id, [FromBody] string password)
    {
        try
        {
            await userLogic.ChangePasswordAsync(id,password);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}