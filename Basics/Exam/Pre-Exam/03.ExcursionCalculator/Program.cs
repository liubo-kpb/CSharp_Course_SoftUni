using System;

namespace _03.ExcursionCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            double cost = 0;
            switch (season)
            {
                case "spring":
                    if (people <= 5)
                    {
                        cost = people * 50.0;
                    } else
                    {
                        cost = people * 48.0;
                    }
                    break;
                case "summer":
                    if (people <= 5)
                    {
                        cost = people * 48.5;
                    }
                    else
                    {
                        cost = people * 45.0;
                    }
                    cost *= .85;
                    break;
                case "autumn":
                    if (people <= 5)
                    {
                        cost = people * 60.0;
                    }
                    else
                    {
                        cost = people * 49.5;
                    }
                    break;
                case "winter":
                    if (people <= 5)
                    {
                        cost = people * 86.0;
                    }
                    else
                    {
                        cost = people * 85.0;
                    }
                    cost *= 1.08;
                    break;
            }

            Console.WriteLine($"{cost:F2} leva.");
        }
    }
}
