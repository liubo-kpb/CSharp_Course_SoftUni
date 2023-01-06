using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _01.MatchFullName
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Regex pattern = new Regex(@"\b[A-Z][a-z]+ [A-Z][a-z]+\b");
            MatchCollection text = pattern.Matches(input);
            
            if (text.Count > 0 )
            {
                Console.WriteLine(string.Join(" ", text));
            }
        }
    }
}
