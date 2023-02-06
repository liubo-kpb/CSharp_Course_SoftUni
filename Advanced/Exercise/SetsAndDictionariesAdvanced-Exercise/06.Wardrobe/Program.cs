using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> clothesByColor = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(new string[] { " -> ", "," }, StringSplitOptions.RemoveEmptyEntries);
                string color = input[0];
                string[] clothing = input.Skip(1).ToArray();

                if (!clothesByColor.ContainsKey(color))
                {
                    clothesByColor[color] = new Dictionary<string, int>();
                }
                for (int x = 0; x < clothing.Length; x++)
                {
                    if (!clothesByColor[color].ContainsKey(clothing[x]))
                    {
                        clothesByColor[color].Add(clothing[x], 0);
                    }
                    clothesByColor[color][clothing[x]]++;
                }
            }

            string[] lookingFor = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string desiredColor = lookingFor[0];
            string desiredClothing = lookingFor[1];
            foreach (var color in clothesByColor)
            {
                Console.WriteLine($"{color.Key} clothes:");
                foreach (var clothing in color.Value)
                {
                    Console.Write($"* {clothing.Key} - {clothing.Value}");
                    if(desiredColor == color.Key && desiredClothing == clothing.Key)
                    {
                        Console.Write(" (found!)");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
