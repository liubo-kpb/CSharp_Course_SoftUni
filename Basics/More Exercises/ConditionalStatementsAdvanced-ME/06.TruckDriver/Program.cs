using System;

namespace _06.TruckDriver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine();
            double km = double.Parse(Console.ReadLine());

            double salary = 0;
            if (km <= 5000) {
                switch (season)
                {
                    case "Spring":
                    case "Autumn":
                        salary = km * 0.75;
                        break;
                    case "Summer":
                        salary = km * 0.90;
                        break;
                    case "Winter":
                        salary = km * 1.05;
                        break;
                }
            } else if (km <= 10000)
            {
                switch (season)
                {
                    case "Spring":
                    case "Autumn":
                        salary = km * 0.95;
                        break;
                    case "Summer":
                        salary = km * 1.10;
                        break;
                    case "Winter":
                        salary = km * 1.25;
                        break;
                }
            } else if (km <= 20000)
            {
                salary = km * 1.45;
            }
            salary *= 4;
            salary *= 0.90;
            Console.WriteLine($"{salary:F2}");
        }
    }
}
