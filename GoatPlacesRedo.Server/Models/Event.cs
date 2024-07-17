namespace GoatPlacesRedo.Server.Domain.Entities;

public class Event
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public ICollection<Participates> Participants { get; set; }
}