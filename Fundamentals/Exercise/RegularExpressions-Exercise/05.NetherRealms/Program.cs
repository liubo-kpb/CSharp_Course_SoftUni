using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _05.NetherRealms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Demon> participants = new List<Demon>();
            string[] demonNames = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var demon in demonNames)
            {
                participants.Add(new Demon(demon));
            }

            foreach (var participant in participants.OrderBy(x => x.Name))
            {
                Console.WriteLine(participant.ToString());
            }
        }

        public class Demon
        {
            public string Name { get; set; }
            public double Health { get; set; }
            public double Damage { get; set; }

            public Demon(string name)
            {
                Name = name;
                Health = GetHealth();
                Damage = GetDamage();
            }

            double GetHealth()
            {
                Regex pattern = new Regex(@"[^0-9\+\-\*\/\.]");
                MatchCollection matches = pattern.Matches(Name);
                double health = 0;
                if (matches.Count > 0)
                {
                    foreach (Match match in matches)
                    {
                        char symbol = char.Parse(match.Value);
                        health += symbol;
                    }
                }
                return health;
            }

            double GetDamage()
            {
                Regex damagePattern = new Regex(@"[\-\+]*\d+\.\d+|[\-\+]*\d+");
                MatchCollection numberMatches = damagePattern.Matches(Name);
                double damage = 0;
                if (numberMatches.Count > 0)
                {
                    foreach (Match match in numberMatches)
                    {
                        string numberString = match.Value;
                        numberString = numberString.Replace("−", "-");
                        double number = double.Parse(numberString);
                        damage += number;
                    }
                    Regex multiplicationDivisionPattern = new Regex(@"[\/\*]");
                    MatchCollection mDMatch = multiplicationDivisionPattern.Matches(Name);
                    foreach (Match match in mDMatch)
                    {
                        char symbol = char.Parse(match.Value);
                        if (symbol == '/')
                        {
                            damage /= 2;
                        }
                        else if (symbol == '*')
                        {
                            damage *= 2;
                        }
                    }
                }
                return damage;
            }

            public override string ToString()
            {
                return $"{Name} - {Health} health, {Damage:F2} damage";
            }
        }
    }
}
