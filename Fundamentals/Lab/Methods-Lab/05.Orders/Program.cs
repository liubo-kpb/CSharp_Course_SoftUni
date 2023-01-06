using System;

namespace _05.Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CalculateCheck(Console.ReadLine(), int.Parse(Console.ReadLine()));
        }

        static void CalculateCheck(string product, int amount)
        {
            switch (product)
            {
                case "coffee":
                    Console.WriteLine($"{1.5 * amount:F2}");
                    break;
                case "water":
                    Console.WriteLine($"{1 * amount:F2}");
                    break;
                case "coke":
                    Console.WriteLine($"{1.4 * amount:F2}");
                    break;
                case "snacks":
                    Console.WriteLine($"{2 * amount:F2}");
                    break;
            }
        }
    }
}
