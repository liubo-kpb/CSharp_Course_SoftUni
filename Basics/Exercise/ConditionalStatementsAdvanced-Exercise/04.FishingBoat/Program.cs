using System;

namespace _04.FishingBoat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fishermen = int.Parse(Console.ReadLine());

            double discount = 0.00;
            if (fishermen <= 6)
            {
                discount = .1;
            } else if (fishermen <= 11 && fishermen >= 7)
            {
                discount = .15;
            } else if (fishermen >= 12)
            {
                discount = 0.25;
            }

            double cost = 0.00;
            switch (season)
            {
                case "Spring":
                    cost = 3000 - (3000 * discount);
                    break;
                case "Summer":
                case "Autumn":
                    cost = 4200 - (4200 * discount);
                    break;
                case "Winter":
                    cost = 2600 - (2600 * discount);
                    break;
            }

            if (fishermen % 2 == 0 && !(season == "Autumn"))
            {
                cost -= cost * 0.05;
            }

            if (cost <= budget)
            {
                Console.WriteLine($"Yes! You have {budget - cost:f2} leva left.");
            } else
            {
                Console.WriteLine($"Not enough money! You need {cost - budget:f2} leva.");
            }
        }
    }
}
