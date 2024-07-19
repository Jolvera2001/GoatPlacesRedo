using GoatPlacesRedo.Server.Domain.Entities;
using GoatPlacesRedo.Server.DTOs;

namespace GoatPlacesRedo.Server.Services;

public interface IUserServices
{
    Task<ClientUser?> GetUser(Guid id);
    Task<User> CreateUser(ClientUser user);
    Task<User> UpdateUser(ClientUser user);
    Task DeleteUser(Guid id);
}