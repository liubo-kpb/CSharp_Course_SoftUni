namespace ExplicitInterfaces.Models.Interfaces
{
    internal interface IResident
    {
        string Name { get; }
        string Country { get; }

        public string GetName();
    }
}
