using System;

namespace _02.BikeRace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int juniors = int.Parse(Console.ReadLine());
            int seniors = int.Parse(Console.ReadLine());
            string track = Console.ReadLine();

            double funds = 0;
            switch (track)
            {
                case "trail":
                    funds = juniors * 5.50 + seniors * 7;
                    break;
                case "cross-country":
                    if (juniors + seniors < 50)
                    {
                        funds = juniors * 8 + seniors * 9.50;
                    } else
                    {
                        funds = (juniors * 8 + seniors * 9.50) * 0.75;
                    }
                    break;
                case "downhill":
                    funds = juniors * 12.25 + seniors * 13.75;
                    break;
                case "road":
                    funds = juniors * 20 + seniors * 21.50;
                    break;
            }
            funds *= 0.95;
            Console.WriteLine($"{funds:F2}");
        }
    }
}
