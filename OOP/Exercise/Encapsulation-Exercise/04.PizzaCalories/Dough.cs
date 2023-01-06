namespace _04.PizzaCalories
{
    using System;
    public class Dough
    {
        private string flourType;
        private double flourModifier;
        private string bakingTechnique;
        private double bakingTechniqueModifier;
        private double grams;
        private double calories;

        public Dough(string flourType, string bakingTechnique, double grams)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Grams = grams;
            Calories = 2 * this.grams * flourModifier * bakingTechniqueModifier;
            
        }

        private string FlourType
        {
            set
            {
                if (value.ToLower() == "white") flourModifier = 1.5;
                else if (value.ToLower() == "wholegrain") flourModifier = 1.0;
                else throw new ArgumentException("Invalid type of dough.");

                flourType = value;
            }
        }

        private string BakingTechnique
        {
            set
            {
                if (value.ToLower() == "crispy") bakingTechniqueModifier = 0.9;
                else if (value.ToLower() == "chewy") bakingTechniqueModifier = 1.1;
                else if (value.ToLower() == "homemade") bakingTechniqueModifier = 1.0;
                else throw new ArgumentException("Invalid type of dough.");

                bakingTechnique = value;
            }
        }

        private double Grams
        {
            set
            {
                if (value < 1 || value > 200) throw new ArgumentException("Dough weight should be in the range [1..200].");

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
