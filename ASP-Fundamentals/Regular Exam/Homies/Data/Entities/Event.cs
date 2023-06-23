namespace Homies.Data.Entities;

using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Event
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(20, MinimumLength = 5)]
    public string Name { get; set; }

    [Required]
    [StringLength(150, MinimumLength = 15)]
    public string Description { get; set; }

    [Required]
    public string OrganiserId { get; set; }

    [Required]
    public IdentityUser Organiser { get; set; }

    [Required]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd H:mm}")]
    public DateTime CreatedOn { get; set; }

    [Required]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd H:mm}")]
    public DateTime Start { get; set; }

    [Required]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd H:mm}")]
    public DateTime End { get; set; }

    [Required]
    [ForeignKey("Type")]
    public int TypeId { get; set; }

    [Required]
    public Type Type { get; set; }

    public ICollection<EventParticipant> EventsParticipants { get; set; }
}
