using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniKindergarten
{
    public class Kindergarten
    {
        private List<Child> registry;

        public Kindergarten(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            registry = new List<Child>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Child> Registry { get { return registry; } }
        public int ChildrenCount { get => registry.Count; }

        public bool AddChild(Child child)
        {
            if (registry.Count < Capacity)
            {
                registry.Add(child);
                return true;
            }
            return false;
        }
        public bool RemoveChild(string childFullName)
        {
            string firstName = childFullName.Split(' ', System.StringSplitOptions.RemoveEmptyEntries)[0];
            string lastName = childFullName.Split(' ', System.StringSplitOptions.RemoveEmptyEntries)[1];
            foreach (Child child in registry)
            {
                if ( child.FirstName == firstName && child.LastName == lastName)
                {
                    registry.Remove(child);
                    return true;
                }
            }
            return false;
        }
        public Child GetChild(string childFullName)
        {
            string firstName = childFullName.Split(' ', System.StringSplitOptions.RemoveEmptyEntries)[0];
            string lastName = childFullName.Split(' ', System.StringSplitOptions.RemoveEmptyEntries)[1];
            foreach (Child child in registry)
            {
                if (child.FirstName == firstName && child.LastName == lastName)
                {
                    return child;
                }
            }
            return null;
        }
        public string RegistryReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Registered children in {Name}:");
            foreach (Child child in registry.OrderByDescending(c => c.Age).ThenBy(c => c.LastName).ThenBy(c => c.FirstName))
            {
                sb.AppendLine(child.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
