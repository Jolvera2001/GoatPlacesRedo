using GoatPlacesRedo.Server.Domain.Entities;
using GoatPlacesRedo.Server.Services;
using Microsoft.EntityFrameworkCore;

namespace GoatPlacesRedo.Server.Repository;

public class UserRepository(GoatDbContext dbContext) : IUserRepository
{
    private readonly GoatDbContext _dbContext = dbContext;
    
    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Set<User>().FindAsync(id);
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _dbContext.Set<User>().ToListAsync();
    }

    public async Task<User> AddAsync(User user)
    {
        await _dbContext.Set<User>().AddAsync(user);
        await _dbContext.SaveChangesAsync();
        return user;
    }

    public async Task<User> UpdateAsync(User user)
    {
        _dbContext.Set<User>().Update(user);
        await _dbContext.SaveChangesAsync();
        return user;
    }

    public async Task DeleteAsync(Guid id)
    {
        var user = await GetByIdAsync(id);
        if (user != null)
        {
            _dbContext.Set<User>().Remove(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}