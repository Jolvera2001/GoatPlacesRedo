using GoatPlacesRedo.Server.Domain.Entities;

namespace GoatPlacesRedo.Server.Services;

public interface IUserServices
{
    Task<User?> GetUser(Guid id);
    Task<User> CreateUser(User user);
    Task<User> UpdateUser(User user);
    Task DeleteUser(Guid id);
}