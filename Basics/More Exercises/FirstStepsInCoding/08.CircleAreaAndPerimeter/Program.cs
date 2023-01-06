using System;

namespace _08.CircleAreaAndPerimeter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double r = double.Parse(Console.ReadLine());
            Console.WriteLine($"{r * r * Math.PI:F2}");
            Console.WriteLine($"{2 * r * Math.PI:F2}");
        }
    }
}
