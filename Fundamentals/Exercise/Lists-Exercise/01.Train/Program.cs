using System;
using System.Linq;
using System.Collections.Generic;

namespace _01.Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> passengersPerWagon = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();
            int space = int.Parse(Console.ReadLine());

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "end")
            {
                int passengers = 0;
                if (command.Contains("Add"))
                {
                    string[] cmdArgs = command.Split(' ');
                    passengers = int.Parse(cmdArgs[1]);
                    passengersPerWagon.Add(passengers);
                }
                else
                {
                    passengers = command.Split().Select(int.Parse).ToArray()[0];
                    for (int i = 0; i < passengersPerWagon.Count; i++)
                    {
                        if (passengersPerWagon[i] + passengers <= space)
                        {
                            passengersPerWagon[i] += passengers;
                            break;
                        }
                    }
                }
            }
            Console.WriteLine(string.Join(" ", passengersPerWagon));
        }
    }
}
