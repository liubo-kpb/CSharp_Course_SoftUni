using System;

namespace _10.WeatherForecast_Part_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double degrees = double.Parse(Console.ReadLine());

            if ( degrees < 5 || degrees > 35)
            {
                Console.WriteLine("unknown");
            }
            else if (26 <= degrees && degrees <= 35) 
            {
                Console.WriteLine("Hot");
            }
            else if (20.1 <= degrees && degrees <= 25.9)
            {
                Console.WriteLine("Warm");
            }
            else if (15 <= degrees && degrees <= 20)
            {
                Console.WriteLine("Mild");
            }
            else if (12 <= degrees && degrees <= 14.9)
            {
                Console.WriteLine("Cool");
            }
            else if (5 <= degrees && degrees <= 11.9)
            {
                Console.WriteLine("Cold");
            }
        }
    }
}
