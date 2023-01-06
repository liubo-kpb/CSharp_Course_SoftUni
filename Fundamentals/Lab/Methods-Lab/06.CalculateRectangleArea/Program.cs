using System;

namespace _06.CalculateRectangleArea
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double area = GetRectangleArea(double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()));
            Console.WriteLine(area);
        }

        static double GetRectangleArea(double width, double height)
        {
            return width * height;
        }
    }
}
