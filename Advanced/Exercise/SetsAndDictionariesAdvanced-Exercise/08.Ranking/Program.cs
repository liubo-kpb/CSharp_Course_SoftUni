using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end of contests")
            {
                string[] details = input.Split(':');
                string contestName = details[0];
                string contestPassword = details[1];
                contests.Add(contestName, contestPassword);
            }

            var candidates = new SortedDictionary<string, Dictionary<string, int>>();
            while ((input = Console.ReadLine()) != "end of submissions")
            {
                string[] details = input.Split("=>");
                string contest = details[0];
                string password = details[1];
                string username = details[2];
                int pointsEarned = int.Parse(details[3]);

                if (contests.ContainsKey(contest) && password == contests[contest])
                {
                    if (!candidates.ContainsKey(username))
                    {
                        candidates[username] = new Dictionary<string, int>();
                        candidates[username][contest] = pointsEarned;
                    }
                    if (!candidates[username].ContainsKey(contest))
                    {
                        candidates[username][contest] = pointsEarned;
                    }
                    if (candidates[username][contest] < pointsEarned)
                    {
                        candidates[username][contest] = pointsEarned;
                    }
                }
            }

            var bestCandidate = candidates.OrderByDescending(x => x.Value.Values.Sum()).First();
            Console.WriteLine($"Best candidate is {bestCandidate.Key} with total {bestCandidate.Value.Values.Sum()} points.");
            Console.WriteLine("Ranking:");
            foreach (var candidate in candidates)
            {
                Console.WriteLine(candidate.Key);
                foreach (var contest in candidate.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
