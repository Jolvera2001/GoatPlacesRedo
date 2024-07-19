using GoatPlacesRedo.Server.Domain.Entities;
using GoatPlacesRedo.Server.DTOs;
using GoatPlacesRedo.Server.Repository;

namespace GoatPlacesRedo.Server.Services;

public class UserServices(IUserRepository repositoryService) : IUserServices
{
    public async Task<ClientUser?> GetUser(Guid id)
    {
        User? domainUser =  await repositoryService.GetByIdAsync(id);

        if (domainUser != null)
        {
            ClientUser user = new ClientUser
            {
                Id = domainUser.Id,
                FirstName = domainUser.FirstName,
                LastName = domainUser.LastName,
                Username = domainUser.Username,
                Password = domainUser.Password,
                Email = domainUser.Email
            };
            
            return user;
        }
        else
        {
            return new ClientUser();
        }
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