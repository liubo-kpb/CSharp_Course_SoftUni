using System;

namespace _04.VegetableMarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double costKgVegetables = double.Parse(Console.ReadLine());
            double costKgFruits = double.Parse(Console.ReadLine());
            int kgVegetables = int.Parse(Console.ReadLine());
            int kgFruits = int.Parse(Console.ReadLine());

            double costBGN = (costKgVegetables * kgVegetables) + (costKgFruits * kgFruits);

            Console.WriteLine($"{euro(costBGN):F2}");
        }

        public static double euro (double bgn)
        {
            return bgn / 1.94;
        }
    }
}
