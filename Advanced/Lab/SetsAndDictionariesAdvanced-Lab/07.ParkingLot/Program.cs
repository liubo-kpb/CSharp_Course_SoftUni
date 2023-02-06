using System;
using System.Collections.Generic;

namespace _07.ParkingLot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            HashSet<string> cars = new HashSet<string>();
            while ((input = Console.ReadLine()) != "END")
            {
                string[] commands = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string action = commands[0];
                string licensePlate = commands[1];

                switch (action)
                {
                    case "IN":
                        cars.Add(licensePlate);
                        break;
                    case "OUT":
                        cars.Remove(licensePlate);
                        break;
                }
            }

            if (cars.Count > 0)
            {
                Console.WriteLine(String.Join(Environment.NewLine, cars));
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
