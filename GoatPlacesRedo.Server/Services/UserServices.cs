using GoatPlacesRedo.Server.Domain.Entities;
using GoatPlacesRedo.Server.Repository;
using Microsoft.Identity.Client;

namespace GoatPlacesRedo.Server.Services;

public class UserServices(RepositoryService<User> repositoryService) : IUserServices
{
    public async Task<User?> GetUser(Guid id)
    {
        return await repositoryService.GetByIdAsync(id);
    }

    public async Task<User> CreateUser(User user)
    {
        return await repositoryService.AddAsync(user);
    }

    public async Task<User> UpdateUser(User user)
    {
        return await repositoryService.UpdateAsync(user);
    }

    public async Task DeleteUser(Guid id)
    {
        await repositoryService.DeleteAsync(id);
    }
}