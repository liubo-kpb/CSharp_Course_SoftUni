using System;

namespace _02.RadiansToDegrees
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter value to convert to degrees: ");

            double radians = double.Parse(Console.ReadLine());
            double degrees = radians * 180 / Math.PI;

            Console.WriteLine(degrees);
        }
    }
}
