using System;

namespace _07.FuelTank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fuel = Console.ReadLine();
            double tankFill = double.Parse(Console.ReadLine());
            double tank = 25;

            if (tankFill >= 25 && (fuel.Equals("Diesel") || fuel.Equals("Gasoline") || fuel.Equals("Gas")))
            {
                Console.WriteLine($"You have enough {fuel.ToLower()}.");
            } else if (tankFill < 25 && (fuel.Equals("Diesel") || fuel.Equals("Gasoline") || fuel.Equals("Gas")))
            {
                Console.WriteLine($"Fill your tank with {fuel.ToLower()}!");
            } else
            {
                Console.WriteLine("Invalid fuel!");
            }
        }
    }
}
