using System;

namespace _04.CleverLily
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double price = double.Parse(Console.ReadLine());
            int toyPrice = int.Parse(Console.ReadLine());

            int moneyGift = 10;
            double savings = 0;
            for (int i = 1; i <= age; i++)
            {
                if (i % 2 == 0)
                {
                    savings += moneyGift -1;
                    moneyGift += 10;
                } else
                {
                    savings += toyPrice;
                }
            }

            if (savings >= price)
            {
                Console.WriteLine($"Yes! {savings - price:F2}");
            }
            else
            {
                Console.WriteLine($"No! {price - savings:F2}");
            }
        }
    }
}
