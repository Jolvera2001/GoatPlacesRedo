using GoatPlacesRedo.Server.Domain.Entities;
using GoatPlacesRedo.Server.DTOs;
using GoatPlacesRedo.Server.Repository;
using Microsoft.Identity.Client;

namespace GoatPlacesRedo.Server.Services;

public class UserServices(RepositoryService<User> repositoryService) : IUserServices
{
    public async Task<User?> GetUser(Guid id)
    {
        return await repositoryService.GetByIdAsync(id);
    }

    public async Task<User> CreateUser(ClientUser user)
    {
        User domainUser = new User
        {
            Id = new Guid(),
            FirstName = user.FirstName,
            LastName = user.LastName,
            Username = user.Username,
            Password = user.Password,
            Email = user.Email
        };
        
        return await repositoryService.AddAsync(domainUser);
    }

    public async Task<User> UpdateUser(ClientUser user)
    {
        User domainUser = new User
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Username = user.Username,
            Password = user.Password,
            Email = user.Email
        };
        
        return await repositoryService.UpdateAsync(domainUser);
    }

    public async Task DeleteUser(Guid id)
    {
        await repositoryService.DeleteAsync(id);
    }
}