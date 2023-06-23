namespace Homies.Models;

public class FormEventViewModel
{
    public string Name { get; set; }

    public string Description { get; set; }

    public DateTime Start { get; set; }
    
    public DateTime End { get; set; }

    public int TypeId { get; set; }

    public IEnumerable<TypeViewModel> Types { get; set; }
}
