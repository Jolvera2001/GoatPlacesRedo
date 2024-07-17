namespace GoatPlacesRedo.Server.Domain.Entities;

public class EventPost : Post
{
    public Guid EventId { get; set; }
    public Event Event { get; set; }
}