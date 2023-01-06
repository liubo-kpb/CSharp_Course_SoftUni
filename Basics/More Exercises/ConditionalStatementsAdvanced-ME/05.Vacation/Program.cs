using System;

namespace _05.Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string location = "";
            string place = "";
            double cost = 0;
            
            if (budget <= 1000)
            {
                place = "Camp";
                switch (season)
                {
                    case "Summer":
                        location = "Alaska";
                        cost = budget * 0.65;
                        break;
                    case "Winter":
                        location = "Morocco";
                        cost = budget * 0.45;
                        break;
                }
            } else if (budget <= 3000)
            {
                place = "Hut";
                switch (season)
                {
                    case "Summer":
                        location = "Alaska";
                        cost = budget * 0.80;
                        break;
                    case "Winter":
                        location = "Morocco";
                        cost = budget * 0.60;
                        break;
                }
            } else if (budget > 3000)
            {
                place = "Hotel";
                switch (season)
                {
                    case "Summer":
                        location = "Alaska";
                        break;
                    case "Winter":
                        location = "Morocco";
                        break;
                }
                cost = budget * 0.90;
            }
            Console.WriteLine($"{location} - {place} - {cost:F2}");
        }
    }
}
