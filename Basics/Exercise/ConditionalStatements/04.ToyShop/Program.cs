using System;

namespace _04.ToyShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double puzzle = 2.6;
            double doll = 3;
            double bear = 4.1;
            double minion = 8.2;
            double truck = 2;

            double vacationPrise = double.Parse(Console.ReadLine());
            int numPuzzles = int.Parse(Console.ReadLine());
            int numDolls = int.Parse(Console.ReadLine());
            int numBears = int.Parse(Console.ReadLine());
            int numMinions = int.Parse(Console.ReadLine());
            int numTrucks = int.Parse(Console.ReadLine());

            int order = numPuzzles + numDolls + numBears + numMinions + numTrucks;
            double cost = (puzzle * numPuzzles) + (doll * numDolls) + (bear * numBears) + (minion * numMinions) + (truck * numTrucks);

            if (order >= 50)
            {
                cost -= (cost * 0.25);
            }

            double rent = cost * 0.1;
            double revenue = cost - rent;

            if (revenue < vacationPrise)
            {
                Console.WriteLine($"Not enough money! {vacationPrise - revenue:F02} lv needed.");
            } else
            {
                Console.WriteLine($"Yes! {revenue - vacationPrise:F02} lv left.");
            }
        }
    }
}
