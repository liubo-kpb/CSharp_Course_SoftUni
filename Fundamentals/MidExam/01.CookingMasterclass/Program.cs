using System;

namespace _01.CookingMasterclass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal budget = decimal.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            decimal flourPrice = decimal.Parse(Console.ReadLine());
            decimal eggPrice = decimal.Parse(Console.ReadLine());
            decimal apronPrice = decimal.Parse(Console.ReadLine());

            decimal price = 0;
            price = (students - (students / 5)) * flourPrice;
            price += 10 * eggPrice * students;
            price += (decimal)(Math.Ceiling(0.2 * students) + students) * apronPrice;

            if (budget >= price)
            {
                Console.WriteLine($"Items purchased for {price:F2}$.");
            } else
            {
                Console.WriteLine($"{price - budget:F2}$ more needed.");
            }
        }
    }
}
