using System;
using System.Collections.Generic;

namespace _8.TrafficJam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> cars = new Queue<string>();
            int carsPass = int.Parse(Console.ReadLine());

            int passedCars = 0;
            string command = Console.ReadLine();
            while (command != "end")
            {
                switch (command)
                {
                    case "green":
                        for (int i = 0; i < carsPass; i++)
                        {
                            if (cars.Count > 0)
                            {
                                ++passedCars;
                                Console.WriteLine($"{cars.Dequeue()} passed!");
                            }
                        }
                        break;
                    default:
                        cars.Enqueue(command);
                        break;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"{passedCars} cars passed the crossroads.");
        }
    }
}
