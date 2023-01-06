using System;

namespace _05.SuppliesForSchool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double pricePens = 5.8;
            double priceMarkes = 7.2;
            double price1L = 1.2;

            //Input
            int packetPens = int.Parse(Console.ReadLine());
            int packetMarkes = int.Parse(Console.ReadLine());
            int liters = int.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine()) / 100;

            double sum = (pricePens * packetPens) + (priceMarkes * packetMarkes) + (price1L * liters);
            double discount = sum * percent;
            double cost = sum - discount;

            Console.WriteLine(cost);
        }
    }
}
