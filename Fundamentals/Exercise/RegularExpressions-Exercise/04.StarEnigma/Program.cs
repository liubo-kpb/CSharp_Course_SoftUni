using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _04.StarEnigma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int messages = int.Parse(Console.ReadLine());
            string message = string.Empty;
            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();
            for (int i = 0; i < messages; i++)
            {
                message = DecrptedMessage(Console.ReadLine());
                Regex pattern = new Regex(@"@(?<planet>[A-Z][a-z]+)[^@\-!:>]*:(?<population>\d+)[^@\-!:>]*!(?<attacktype>A|D)![^@\-!:>]*->(?<soldiers>\d+)");
                Match match = pattern.Match(message);
                if (match.Success)
                {
                    string planet = match.Groups["planet"].Value;
                    char attackType = char.Parse(match.Groups["attacktype"].Value);
                    CheckAction(attackType, planet, attackedPlanets, destroyedPlanets);
                }
            }
            PrintMovements(attackedPlanets, destroyedPlanets);
        }

        static void PrintMovements(List<string> attackedPlanets, List<string> destroyedPlanets)
        {
            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
            foreach (string planet in attackedPlanets.OrderBy(x => x))
            {
                Console.WriteLine("-> " + planet);
            }
            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
            foreach (string planet in destroyedPlanets.OrderBy(x => x))
            {
                Console.WriteLine("-> " + planet);
            }
        }

        static void CheckAction(char attackType, string planet, List<string> attackedPlanets, List<string> destroyedPlanets)
        {
            if (attackType == 'A')
            {
                attackedPlanets.Add(planet);
            }
            else if (attackType == 'D')
            {
                destroyedPlanets.Add(planet);
            }
        }

        static string DecrptedMessage(string message)
        {
            int decryptBy = 0;
            for (int i = 0; i < message.Length; i++)
            {
                char c = char.ToLower(message[i]);
                if (c == 's' || c == 't' || c == 'a' || c == 'r')
                {
                    decryptBy++;
                }
            }

            StringBuilder decryptedMessage = new StringBuilder();
            foreach (var ch in message)
            {
                decryptedMessage.Append((char)(ch - decryptBy));
            }
            return decryptedMessage.ToString();
        }
    }
}
