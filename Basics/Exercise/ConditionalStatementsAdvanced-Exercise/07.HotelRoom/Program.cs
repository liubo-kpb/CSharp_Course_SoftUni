using System;

namespace _07.HotelRoom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());

            double studioCost = 0.00;
            double apartmentCost = 0.00;

            switch (month)
            {
                case "May":
                case "October":
                    studioCost = 50;
                    apartmentCost = 65;

                    if (nights > 14)
                    {
                        studioCost *= 0.7;
                    } else if (nights > 7)
                    {
                        studioCost *= 0.95;
                    }

                        break;
                case "June":
                case "September":
                    studioCost = 75.20;
                    apartmentCost = 68.70;

                    if (nights > 14)
                    {
                        studioCost *= 0.80;
                    }

                    break;

                case "July":
                case "August":
                    studioCost = 76;
                    apartmentCost = 77;
                    break;
            }

            if (nights > 14)
            {
                apartmentCost *= 0.90;
            }

            Console.WriteLine($"Apartment: {apartmentCost * nights:F2} lv.");
            Console.WriteLine($"Studio: {studioCost * nights:F2} lv.");
        }
    }
}
