﻿namespace Homies.Models;

public class EventViewModel
{
    public int Id { get; set; }

    public string Name { get; set; }
    
    public DateTime Start { get; set; }

    public string Type { get; set; }
    
    public string Organiser { get; set; }
}
