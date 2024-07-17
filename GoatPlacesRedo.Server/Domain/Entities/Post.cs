namespace GoatPlacesRedo.Server.Domain.Entities;

public class Post
{
    public string Id { get; set; }
    public User UserId { get; set; }
    public string body { get; set; }
}