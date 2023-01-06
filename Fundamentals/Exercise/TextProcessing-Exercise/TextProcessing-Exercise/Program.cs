using System;
using System.Linq;

namespace TextProcessing_Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine().Split(", ");
            foreach (var username in usernames)
            {
                char[] symbols = username.ToArray();
                bool containsSpecialCharacter = false;
                foreach (char c in symbols)
                {
                    if (!char.IsLetterOrDigit(c) && c != '-' && c != '_')
                    {
                        containsSpecialCharacter = true;
                        break;
                    }
                }
                if (username.Length > 3 && username.Length < 16 && !containsSpecialCharacter)
                {
                    Console.WriteLine(username);
                }

            }
        }
    }
}
