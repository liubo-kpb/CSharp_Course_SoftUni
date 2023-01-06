using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] participants = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, double> results = new Dictionary<string, double>();
            foreach (string participant in participants)
            {
                results[participant] = 0;
            }

            Regex pattern = new Regex(@"[A-Za-z\d]");
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end of race")
            {
                MatchCollection details = pattern.Matches(input);
                double kms = 0;
                StringBuilder name = new StringBuilder();
                foreach (Match match in details)
                {
                    if (char.IsDigit(match.Value.ToCharArray()[0]))
                    {
                        kms += double.Parse(match.Value);
                    }
                    else
                    {
                        name.Append(match.Value);
                    }
                }
                string participantName = name.ToString();
                if (results.ContainsKey(participantName))
                {
                    results[participantName] += kms;
                }
            }
            Console.WriteLine($"1st place: {FindWinner(results)}");
            Console.WriteLine($"2nd place: {FindWinner(results)}");
            Console.WriteLine($"3rd place: {FindWinner(results)}");
        }

        static string FindWinner(Dictionary<string, double> participants)
        {
            double mostKm = -1;
            string participant = string.Empty;
            foreach (var racer in participants)
            {
                if (racer.Value > mostKm)
                {
                    mostKm = racer.Value;
                    participant = racer.Key;
                }
            }
            participants.Remove(participant);
            return participant;
        }
    }
}
