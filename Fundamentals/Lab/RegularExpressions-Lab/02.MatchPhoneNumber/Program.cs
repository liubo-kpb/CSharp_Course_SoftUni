using System;
using System.Text.RegularExpressions;

namespace _02.MatchPhoneNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Regex pattern = new Regex(@"\+359( |-)2\1[\d]{3}\1[\d]{4}\b");
            MatchCollection numbers = pattern.Matches(input);

            if (numbers.Count > 0)
            {
                Console.WriteLine(string.Join(", ", numbers));
            }
        }
    }
}
