namespace Homies.Data.Entities;

using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class EventParticipant
{
    [ForeignKey("Helper")]
    [Required]
    public string HelperId { get; set; }

    [Required]
    public IdentityUser Helper { get; set; }

    [ForeignKey("Event")]
    [Required]
    public int EventId { get; set; }

    [Required]
    public Event Event { get; set; }
}
