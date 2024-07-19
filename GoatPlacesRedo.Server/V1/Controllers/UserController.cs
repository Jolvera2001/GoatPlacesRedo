using GoatPlacesRedo.Server.Domain.Entities;
using GoatPlacesRedo.Server.DTOs;
using GoatPlacesRedo.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace GoatPlacesRedo.Server.V1.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class UserController(UserServices userServices) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser([FromRoute]Guid id)
    {
        var user = await userServices.GetUser(id);
        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> InsertUser([FromBody] ClientUser? user)
    {
        if (user == null)
        {
            return BadRequest();
        }

        User createdUser = await userServices.CreateUser(user);
        
        return Ok(createdUser);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUser([FromBody] ClientUser? user)
    {
        if (user == null)
        {
            return BadRequest();
        }

        User updatedUser = await userServices.UpdateUser(user);

        return Ok(updatedUser);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
    {
        await userServices.DeleteUser(id);
        return Ok();
    }
    
}