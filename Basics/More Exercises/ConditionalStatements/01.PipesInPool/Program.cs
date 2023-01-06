using System;

namespace _01.PipesInPool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int v = int.Parse(Console.ReadLine());
            int p1 = int.Parse(Console.ReadLine());
            int p2 = int.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            double fill = (p1 + p2) * h;
            
            if (fill <= v)
            {
                double fullPercent = fill / v * 100.00;
                double p1Fill = p1 * h / fill * 100.00;
                double p2Fill = p2 * h / fill * 100.00;
                
                Console.WriteLine($"The pool is {fullPercent:F2}% full. Pipe 1: {p1Fill:F2}%. Pipe 2: {p2Fill:F2}%.");
            } else
            {
                Console.WriteLine($"For {h:F2} hours the pool overflows with {(fill - v):F2} liters.");
            }
        }
    }
}
