using System;

namespace _05.Digits_LettersAndOther
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string letters = string.Empty;
            string specialChars = string.Empty;

            foreach (char character in input)
            {
                if (Char.IsDigit(character))
                {
                    Console.Write(character);
                } else if (Char.IsLetter(character))
                {
                    letters += character;
                } else
                {
                    specialChars += character;
                }
            }
            Console.WriteLine();
            Console.WriteLine(letters);
            Console.WriteLine(specialChars);
        }
    }
}
