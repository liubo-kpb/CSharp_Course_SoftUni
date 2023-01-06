namespace _04.PizzaCalories
{
    using System;
    using System.Collections.Generic;

    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;
        private double calories;

        public Pizza(string name)
        {
            Name = name;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 15) throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");

                name = value;
            }
        }
        public Dough Dough { set { dough = value; } }
        public int NumberOfToppings { get { return toppings.Count; } }
        public double Calories
        {
            get 
            {
                Calories = 0;
                return calories;
            }
            private set
            {
                calories = double.Parse(dough.ToString());
                for (int i = 0; i < toppings.Count; i++)
                {
                    calories += double.Parse(toppings[i].ToString());
                }
            }
        }
        public override string ToString() => $"{name} - {Calories:F2} Calories.";

        public void AddTopping(Topping topping)
        {
            if (toppings == null) toppings = new List<Topping>();
            
            if (toppings.Count > 10) throw new ArgumentException("Number of toppings should be in range [0..10].");

            toppings.Add(topping);
        }
    }
}
