using System;

namespace _08.FuelTank_Part2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fuel = Console.ReadLine();
            int quantityFuel = int.Parse(Console.ReadLine());
            string clubCard = Console.ReadLine();

            double gasoline = 2.22;
            double diesel = 2.33;
            double gas = 0.93;

            if (clubCard == "Yes")
            {
                gasoline = gasoline - 0.18;
                diesel -= 0.12;
                gas -= 0.08;
            }

            double cost = 0.00;

            if (fuel == "Gasoline")
            {
                cost = quantityFuel * gasoline;
            } else if (fuel == "Diesel")
            {
                cost = quantityFuel * diesel;
            } else if (fuel == "Gas")
            {
                cost = quantityFuel * gas;
            }

            if (quantityFuel >= 20 && quantityFuel <= 25)
            {
                cost -= (cost * 0.08);
            } else if (quantityFuel > 25)
            {
                cost -= (cost * 0.1);
            }

            Console.WriteLine($"{cost:f2} lv.");
        }
    }
}
