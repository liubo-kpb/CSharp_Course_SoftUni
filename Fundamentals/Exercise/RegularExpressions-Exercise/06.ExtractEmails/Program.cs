using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _06.ExtractEmails
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<string> emails = new List<string>();
            Regex pattern = new Regex(@"((^)|(?<=\s))[A-Za-z0-9]+[\w\.\-]*@[A-Za-z0-9]+([\-\.][A-Za-z]+)+");
            MatchCollection matches = pattern.Matches(input);
            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    Console.WriteLine(match);
                }
            }
        }
    }
}
