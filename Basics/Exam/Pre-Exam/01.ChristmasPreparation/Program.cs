using System;

namespace _01.ChristmasPreparation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rollsPaper = int.Parse(Console.ReadLine());
            int rollsOfCloth = int.Parse(Console.ReadLine());
            double glue = double.Parse(Console.ReadLine());
            int discount = int.Parse(Console.ReadLine());

            double cost = ((rollsPaper * 5.8) + (rollsOfCloth * 7.2) + (glue * 1.2)) * (100 - discount) / 100;
            Console.WriteLine($"{cost:F3}");
            
        }
    }
}
