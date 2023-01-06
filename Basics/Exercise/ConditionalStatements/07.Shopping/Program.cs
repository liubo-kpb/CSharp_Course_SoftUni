using System;

namespace _07.Shopping
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int gpu = int.Parse(Console.ReadLine());
            int cpu = int.Parse(Console.ReadLine());
            int ram = int.Parse(Console.ReadLine());

            double gpuCost = 250 * gpu;
            double cpuCost = gpuCost * .35 * cpu;
            double ramCost = gpuCost * .1 * ram;

            double cost = gpuCost + cpuCost + ramCost;

            if (gpu > cpu)
            {
                cost = cost - (cost * 0.15);
            }

            if (cost <= budget)
            {
                Console.WriteLine($"You have {budget - cost:F02} leva left!");
            } else
            {
                Console.WriteLine($"Not enough money! You need {cost - budget:F02} leva more!");
            }
        }
    }
}
