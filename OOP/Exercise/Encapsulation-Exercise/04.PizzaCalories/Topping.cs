namespace _04.PizzaCalories
{
    using System;
    public class Topping
    {
        private string typeOfTopping;
        private double toppingModifier;
        private double grams;
        private double calories;

        public Topping(string typeOfTopping, double grams)
        {
            TypeOfTopping = typeOfTopping;
            Grams = grams;
            Calories = 2 * this.grams * toppingModifier;
        }

        private string TypeOfTopping
        {
            set
            {
                if (value.ToLower() == "meat") toppingModifier = 1.2;
                else if (value.ToLower() == "veggies") toppingModifier = 0.8;
                else if (value.ToLower() == "cheese") toppingModifier = 1.1;
                else if (value.ToLower() == "sauce") toppingModifier = 0.9;
                else throw new ArgumentException($"Cannot place {value} on top of your pizza.");

                typeOfTopping = value;
            }
        }

        private double Grams
        {
            set
            {
                if (value < 1 || value > 50) throw new ArgumentException($"{typeOfTopping} weight should be in the range [1..50].");

                grams = value;
            }
        }

        private double Calories
        {
            set
            {
                calories = value;
            }
        }

        public double CaloriesPerGram
        {
            get { return calories / grams; }
        }

        public override string ToString() => $"{calories:F2}";
    }
}
