using System;

namespace _06.MiddleCharacters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();

            Console.WriteLine(FindMiddleString(str));
        }

        static string FindMiddleString (string str)
        {
            string middleString = string.Empty;

            if (str.Length % 2 == 0)
            {
                middleString += str[str.Length / 2 - 1];
                middleString += str[str.Length / 2];
            }
            else
            {
                middleString += str[str.Length / 2];
            }

            return middleString;
        }
    }
}
