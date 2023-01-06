using System;

namespace _07.AreaOfFigures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string figureName = Console.ReadLine();

            if (figureName == "square")
            {
                double side = double.Parse(Console.ReadLine());
                double area = side * side;
                Console.WriteLine($"{area:F3}");
            } else if (figureName == "rectangle")
            {
                double sideA = double.Parse(Console.ReadLine());
                double sideB = double.Parse(Console.ReadLine());
                double area = sideA * sideB;
                Console.WriteLine($"{area:F3}");
            } else if (figureName == "circle")
            {
                double raius = double.Parse(Console.ReadLine());
                double area = raius * raius * Math.PI;
                Console.WriteLine($"{area:F3}");
            } else if (figureName == "triangle")
            {
                double sideA = double.Parse(Console.ReadLine());
                double sideB = double.Parse(Console.ReadLine());
                double area = sideA * sideB / 2;
                Console.WriteLine($"{area:F3}");
            }
        }
    }
}
