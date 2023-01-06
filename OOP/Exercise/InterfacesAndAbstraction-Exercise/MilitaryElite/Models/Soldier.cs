namespace MilitaryElite.Models
{
    using Interfaces;
    internal class Soldier : ISoldier
    {

        public Soldier(string firstName, string lastName, string id)
        {
            FirstName = firstName;
            LastName = lastName;
            Id = id;
        }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Id { get; private set; }

        public override string ToString() => $"Name: {FirstName} {LastName} Id: {Id}";
        
    }
}
