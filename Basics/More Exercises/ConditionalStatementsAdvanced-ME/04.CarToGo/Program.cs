using System;

namespace _04.CarToGo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string carClass = "";
            double carCost = 0.00;
            string carType = "";
            if (budget <= 100)
            {
                carClass = "Economy class";
                switch (season)
                {
                    case "Summer":
                        carType = "Cabrio";
                        carCost = budget * 0.35;
                        break;
                    case "Winter":
                        carType = "Jeep";
                        carCost = budget * 0.65;
                        break;
                }
            } else if (budget <= 500)
            {
                carClass = "Compact class";
                switch (season)
                {
                    case "Summer":
                        carType = "Cabrio";
                        carCost = budget * 0.45;
                        break;
                    case "Winter":
                        carType = "Jeep";
                        carCost = budget * 0.80;
                        break;
                }
            }
            else if (budget > 500)
            {
                carClass = "Luxury class";
                carType = "Jeep";
                carCost = budget * 0.90;
            }
            Console.WriteLine(carClass);
            Console.WriteLine($"{carType} - {carCost:F2}");
        }
    }
}
