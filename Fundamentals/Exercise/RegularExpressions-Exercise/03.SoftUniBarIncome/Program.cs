using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03.SoftUniBarIncome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Regex pattern = new Regex(@"%([A-Z][a-z]+)%[^\|\$\%\.]*<(\w+)>[^\|\$\%\.]*\|(\d+)[^\|\$\%\.]*\|[^\|\$\%\.]*?(\d+.\d*)\$");
            double totalSum = 0;
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end of shift")
            {
                Match match = pattern.Match(input);
                if (match.Length > 0)
                {
                    string name = match.Groups[1].Value;
                    string product = match.Groups[2].Value;
                    int count = int.Parse(match.Groups[3].Value);
                    double price = double.Parse(match.Groups[4].Value);
                    double clientTab = count * price;
                    Console.WriteLine($"{name}: {product} - {clientTab:F2}");
                    totalSum += clientTab;
                }
            }
            Console.WriteLine($"Total income: {totalSum:F2}");
        }
    }
}
