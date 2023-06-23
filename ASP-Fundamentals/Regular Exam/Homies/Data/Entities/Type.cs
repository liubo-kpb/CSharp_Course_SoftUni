namespace Homies.Data.Entities;

using System.ComponentModel.DataAnnotations;

public class Type
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(15, MinimumLength = 5)]
    public string Name { get; set; }

    public ICollection<Event> Events { get; set; }
}
