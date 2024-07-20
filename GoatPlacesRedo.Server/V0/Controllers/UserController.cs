using FluentValidation.Results;
using GoatPlacesRedo.Server.Domain.Entities;
using GoatPlacesRedo.Server.DTOs;
using GoatPlacesRedo.Server.Helpers.Validation;
using GoatPlacesRedo.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace GoatPlacesRedo.Server.V0.Controllers;

[ApiController]
[Route("api/v0/[controller]")]
public class UserController(IUserServices userServices) : ControllerBase
{
    private UserValidation _validator = new UserValidation();
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser([FromBody]Guid id)
    {
        ClientUser? user = await userServices.GetUser(id);

        if (user == null)
        {
            return BadRequest();
        }
        
        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> InsertUser([FromBody] ClientUser? user)
    {
        ValidationResult result = await _validator.ValidateAsync(user);
        
        if (result.IsValid)
        {
            var createdUser = await userServices.CreateUser(user);
            return Ok(createdUser);
        }

        return BadRequest();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUser([FromBody] ClientUser? user)
    {
        ValidationResult result = await _validator.ValidateAsync(user);
        
        if (result.IsValid)
        {
            User updatedUser = await userServices.UpdateUser(user);
            return Ok(updatedUser);
        }

        return BadRequest();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
    {
        await userServices.DeleteUser(id);
        return Ok();
    }
    
}