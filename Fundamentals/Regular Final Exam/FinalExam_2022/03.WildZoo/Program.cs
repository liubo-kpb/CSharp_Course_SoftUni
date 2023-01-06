using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.WildZoo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> animals = new Dictionary<string, Dictionary<string, int>>();
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "EndDay")
            {
                string[] cmdArgs = command.Split(": ");
                string action = cmdArgs[0];

                string animalName = string.Empty;
                switch (action)
                {
                    case "Add":
                        string[] animalDetails = cmdArgs[1].Split('-');
                        animalName = animalDetails[0];
                        int requiredFood = int.Parse(animalDetails[1]);
                        string area = animalDetails[2];

                        if (!animals.ContainsKey(area))
                        {
                            animals[area] = new Dictionary<string, int>();
                        }
                        if (!animals[area].ContainsKey(animalName))
                        {
                            animals[area][animalName] = 0;
                        }
                        animals[area][animalName] += requiredFood;
                        break;
                    case "Feed":
                        string[] feedingDetails = cmdArgs[1].Split("-");
                        animalName = feedingDetails[0];
                        int foodProvided = int.Parse(feedingDetails[1]);
                        foreach (var location in animals.Where(x => x.Value.ContainsKey(animalName)))
                        {
                            location.Value[animalName] -= foodProvided;
                            if (location.Value[animalName] <= 0)
                            {
                                animals[location.Key].Remove(animalName);
                                Console.WriteLine($"{animalName} was successfully fed");
                            }
                        }
                        break;
                }
            }
            Console.WriteLine("Animals:");
            foreach (var item in animals)
            {
                foreach (var animal in item.Value)
                {
                    Console.WriteLine($" {animal.Key} -> {animal.Value}g");
                }
            }
            Console.WriteLine("Areas with hungry animals:");
            foreach (var item in animals)
            {
                if (item.Value.Count > 0)
                {
                    Console.WriteLine($" {item.Key}: {item.Value.Count}");
                }
            }
        }
    }
}
