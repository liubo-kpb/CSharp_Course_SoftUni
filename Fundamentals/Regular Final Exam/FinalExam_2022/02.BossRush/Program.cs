using System;
using System.Text.RegularExpressions;

namespace _02.BossRush
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int inputs = int.Parse(Console.ReadLine());
            Regex pattern = new Regex(@"(\|)(?<name>[A-Z]{4,})\1:(#)(?<title>[A-Za-z]+ [A-Za-z]+)\2");

            for (int i = 0; i < inputs; i++)
            {
                string bossDetails = Console.ReadLine();
                if (bossDetails.Length == 0)
                {
                    --i;
                    continue;
                }
                Match match = pattern.Match(bossDetails);
                if (match.Success)
                {
                    string bossName = match.Groups["name"].Value;
                    string bossTitle = match.Groups["title"].Value;
                    Console.WriteLine($"{bossName}, The {bossTitle}");
                    Console.WriteLine($">> Strength: {bossName.Length}");
                    Console.WriteLine($">> Armor: {bossTitle.Length}");
                }
                else
                {
                    Console.WriteLine("Access denied!");
                }
            }
        }
    }
}
