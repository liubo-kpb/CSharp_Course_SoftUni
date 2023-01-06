using System;

namespace _07.FoodDelivery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double chickenMenu = 10.35;
            double fishMenu = 12.4;
            double vegetarianMenu = 8.15;
            double delivery = 2.5;
            
            int chickenOrders = int.Parse(Console.ReadLine());
            int fishOrders = int.Parse(Console.ReadLine());
            int vegetarianOrders = int.Parse(Console.ReadLine());

            double desert = ((chickenMenu * chickenOrders) + (fishMenu * fishOrders) + (vegetarianMenu * vegetarianOrders)) * 0.2;
            double cost = (chickenMenu * chickenOrders) + (fishMenu * fishOrders) + (vegetarianMenu * vegetarianOrders) + desert + delivery;

            Console.WriteLine(cost);
        }
    }
}
