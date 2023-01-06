using System;

namespace _09.YardGreening
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double costPerM2 = 7.61;
            double m2 = double.Parse(Console.ReadLine());

            double cost = costPerM2 * m2;
            double discount = cost * 0.18;
            double finalCost = cost - discount;

            Console.WriteLine($"The final prices is: {finalCost} lv.");
            Console.WriteLine($"The discount is: {discount} lv.");
        }
    }
}
