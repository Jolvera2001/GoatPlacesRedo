using GoatPlacesRedo.Server.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GoatPlacesRedo.Server.Services;

public class GoatDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<EventPost> EventPosts { get; set; }
    public DbSet<Participates> Participating { get; set; }

    public GoatDbContext(DbContextOptions<GoatDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Participates>()
            .HasKey(p => new { p.UserId, p.EventId });

        modelBuilder.Entity<Participates>()
            .HasOne(p => p.User)
            .WithMany(u => u.ParticipatesCollection)
            .HasForeignKey(p => p.UserId);

        modelBuilder.Entity<Participates>()
            .HasOne(p => p.Event)
            .WithMany(u => u.Participants)
            .HasForeignKey(p => p.EventId);
    
        base.OnModelCreating(modelBuilder);

    }
}