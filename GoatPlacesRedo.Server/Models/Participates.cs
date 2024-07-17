﻿namespace GoatPlacesRedo.Server.Domain.Entities;

public class Participates
{
    public Guid UserId { get; set; }
    public User User { get; set; }
    
    public Guid EventId { get; set; }
    public Event Event { get; set; }
}