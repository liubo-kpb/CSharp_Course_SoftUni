using System;
using System.Collections.Generic;

namespace _05.CitiesByContinentAndCountry
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, List<string>>> continets = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < lines; i++)
            {
                string[] details = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string continent = details[0];
                string country = details[1];
                string city = details[2];

                if (!continets.ContainsKey(continent))
                {
                    continets.Add(continent, new Dictionary<string, List<string>>());
                }
                if (!continets[continent].ContainsKey(country))
                {
                    continets[continent].Add(country, new List<string>());
                }
                continets[continent][country].Add(city);
            }

            foreach (var continent in continets)
            {
                Console.WriteLine(continent.Key + ":");
                foreach (var country in continent.Value)
                {
                    Console.WriteLine($"  {country.Key} -> {string.Join(", ", country.Value)}");
                }
            }
        }
    }
}
