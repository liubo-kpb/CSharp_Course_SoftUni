using System;

namespace _08.TennisRanklist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int tourneys = int.Parse(Console.ReadLine());
            int startingPoints = int.Parse(Console.ReadLine());

            double points = startingPoints;
            double tourneysWon = 0.00;
            for (int i = 0; i < tourneys; i++)
            {
                string finish = Console.ReadLine();

                switch (finish)
                {
                    case "W":
                        points += 2000;
                        tourneysWon++;
                        break;
                    case "F":
                        points += 1200;
                        break;
                    case "SF":
                        points += 720;
                        break;
                }
            }

            Console.WriteLine($"Final points: {points}");
            Console.WriteLine($"Average points: {Math.Floor((points - startingPoints) / tourneys)}");
            Console.WriteLine($"{tourneysWon / tourneys * 100:F2}%");
        }
    }
}
