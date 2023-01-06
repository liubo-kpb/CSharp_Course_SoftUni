using System;

namespace _02.FootballKit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double priceTshirt = double.Parse(Console.ReadLine());
            double specialPrice = double.Parse(Console.ReadLine());

            double priceShorts = priceTshirt * .75;
            double priceSocks = priceShorts * .2;
            double priceShoes = (priceTshirt + priceShorts) * 2;
            double discount = .15;

            double cost = (priceTshirt + priceShorts + priceSocks + priceShoes) * (1 - discount);
            
            if (cost >= specialPrice)
            {
                Console.WriteLine("Yes, he will earn the world-cup replica ball!");
                Console.WriteLine($"His sum is {cost:F2} lv.");
            } else
            {
                Console.WriteLine("No, he will not earn the world-cup replica ball.");
                Console.WriteLine($"He needs {specialPrice - cost:F2} lv. more.");
            }
        }
    }
}
