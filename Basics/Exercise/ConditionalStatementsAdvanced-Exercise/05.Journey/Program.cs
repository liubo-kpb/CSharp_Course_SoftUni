using System;

namespace _05.Journey
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string typeOfVacation = null;
            string location = null;
            double spend = 0.00;

            if (budget <= 100)
            {
                location = "Bulgaria";
                switch (season)
                {
                    case "summer":
                        typeOfVacation = "Camp";
                        spend = budget * 0.3;
                        break;
                    case "winter":
                        typeOfVacation = "Hotel";
                        spend = budget * 0.7;
                        break;
                }
            } else if (budget <= 1000)
            {
                location = "Balkans";
                switch (season)
                {
                    case "summer":
                        typeOfVacation = "Camp";
                        spend = budget * 0.4;
                        break;
                    case "winter":
                        typeOfVacation = "Hotel";
                        spend = budget * 0.8;
                        break;
                }
            } else if (budget > 1000)
            {
                location = "Europe";
                typeOfVacation = "Hotel";
                spend = budget * 0.9;
            }
            Console.WriteLine($"Somewhere in {location}");
            Console.WriteLine($"{typeOfVacation} - {spend:f2}");
            
        }
    }
}
