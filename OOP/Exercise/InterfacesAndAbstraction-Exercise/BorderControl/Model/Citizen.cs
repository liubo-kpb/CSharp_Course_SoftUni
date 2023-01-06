namespace BorderControl.Model
{
    using Interfaces;
    internal class Citizen : ICitizen, IBuyer
    {
        public const int FOOD_CAPACITY = 10;
        public Citizen(string name, int age, string id, string birthday)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthday = birthday;
            Food = 0;
        }
        
        public Citizen(string name, int age, string id)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthday = "We're only looking for intruders at this time. Birthdays are not a priority. Move along!";
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Id { get; private set; }

        public string Birthday { get; private set; }

        public int Food {get; private set; }

        public int FOOD_CAPACITY_PROP { get => FOOD_CAPACITY; }

        public void BuyFood() => Food += FOOD_CAPACITY;
        
    }
}
