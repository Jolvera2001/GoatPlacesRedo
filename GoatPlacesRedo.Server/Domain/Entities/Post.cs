namespace GoatPlacesRedo.Server.Domain.Entities;

public class Post
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public string body { get; set; }
}