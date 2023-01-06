using System;
using System.Text.RegularExpressions;

namespace _03.MatchDates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Regex pattern = new Regex(@"\b(?<date>\d{2})(\.|-|\/)(?<month>[A-Z][a-z]{2})\1(?<year>\d{4})\b");
            MatchCollection dates= pattern.Matches(input);

            if (dates.Count > 0)
            {
                foreach (Match date in dates)
                {
                    Console.WriteLine($"Day: {date.Groups["date"].Value}, Month: {date.Groups["month"].Value}, Year: {date.Groups["year"].Value}");
                }
            }
        }
    }
}
