
namespace BorderControl.Model
{
    using Interfaces;
    public class Rebel : ICitizen, IBuyer
    {

        public const int FOOD_CAPACITY = 5;
        public Rebel(string name, int age, string group)
        {
            Name = name;
            Age = age;
            Group = group;
            Id = "No ID = Rebel!";
            Food = 0;
        }
        public int Age { get; private set; }

        public string Name { get; private set; }

        public string Birthday { get; private set; }

        public string Id { get; private set; }

        public int Food { get; private set; }

        public string Group { get; private set; }

        public int FOOD_CAPACITY_PROP { get => FOOD_CAPACITY; }
        public void BuyFood() => Food += FOOD_CAPACITY;
    }
}
