using System;
using System.Collections.Generic;

namespace _02.AMinerTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> ressources = new Dictionary<string, int>();
            string ressource = string.Empty;
            while ((ressource = Console.ReadLine()) != "stop")
            {
                int quantity = int.Parse(Console.ReadLine());
                if (!ressources.ContainsKey(ressource))
                {
                    ressources[ressource] = 0;
                }
                ressources[ressource] += quantity;
            }
            foreach (var item in ressources)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
