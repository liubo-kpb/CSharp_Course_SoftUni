namespace BorderControl.Model
{
    using Interfaces;
    public class Pet : IBiological
    {
        public Pet(string name, string birthday)
        {
            Name = name;
            Birthday = birthday;
            Id = "Pets don't have IDs. Move along!";
        }
        public string Name { get; private set; }

        public string Birthday { get; private set; }

        public string Id { get; private set; }
    }
}
