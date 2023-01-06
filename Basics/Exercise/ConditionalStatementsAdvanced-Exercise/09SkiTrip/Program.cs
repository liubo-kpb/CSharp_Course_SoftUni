using System;

namespace _09SkiTrip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string place = Console.ReadLine();
            string feedback = Console.ReadLine();

            int nights = days - 1;

            double cost = 0.00;
            switch (place)
            {
                case "room for one person":
                    cost = nights * 18.0;
                    break;
                case "apartment":
                    cost = nights * 25.0;
                    if (days < 10)
                    {
                        cost *= 0.70;
                    } else if (days >= 10 && days <= 15)
                    {
                        cost *= 0.65;
                    } else if (days > 15)
                    {
                        cost *= 0.50;
                    }
                    break;
                case "president apartment":
                    cost = nights * 35.0;
                    if (days < 10)
                    {
                        cost *= 0.90;
                    }
                    else if (days >= 10 && days <= 15)
                    {
                        cost *= 0.85;
                    }
                    else if (days > 15)
                    {
                        cost *= 0.80;
                    }
                    break;
            }

            if (feedback == "positive")
            {
                cost += cost * 0.25;
            } else if (feedback == "negative")
            {
                cost -= cost * 0.10;
            }

            Console.WriteLine($"{cost:F2}");
        }
    }
}
