using System;

namespace _07.HousePainting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            double green = 3.4;
            double red = 4.3;

            double gfbArea = 2 * x * x - (1.2 * 2);
            double gSideArea = 2 * y * x - (2 * 1.5 * 1.5);
            double rfbArea = 2 * h * x / 2;
            double rSideArea = 2 * x * y;

            double gLiters = (gfbArea + gSideArea) / green;
            double rLiters = (rfbArea + rSideArea) / red;

            Console.WriteLine($"{gLiters:F2}");
            Console.WriteLine($"{rLiters:F2}");
        }
    }
}
