using System;

namespace _01.Cinema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string projection = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int columns = int.Parse(Console.ReadLine());

            double price = 0;
            switch (projection)
            {
                case "Premiere":
                    price = rows * columns * 12.0;
                    break;
                case "Normal":
                    price = rows * columns * 7.5;
                    break;
                case "Discount":
                    price = rows * columns * 5.0;
                    break;
            }
            Console.WriteLine($"{price:F2} leva");
        }
    }
}
