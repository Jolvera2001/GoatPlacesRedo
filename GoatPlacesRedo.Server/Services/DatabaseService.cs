using GoatPlacesRedo.Server.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GoatPlacesRedo.Server.Domain.Services;

public class DatabaseService(DbContextOptions<DatabaseService> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<EventPost> EventPosts { get; set; }
    public DbSet<Participates> Participating { get; set; }
}