using System;
using System.Text;

namespace _06.ReplaceRepeatingChars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int charIndex = 0;
            StringBuilder newString = new StringBuilder();
            newString.Append(input[charIndex]);
            for (int i = 1; i < input.Length; i++)
            {
                if (input[charIndex] != input[i])
                {
                    newString.Append(input[i]);
                    charIndex = i;
                }
            }
            Console.WriteLine(newString);
        }
    }
}
