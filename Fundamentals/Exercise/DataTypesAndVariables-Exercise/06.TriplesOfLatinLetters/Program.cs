using System;

namespace _06.TriplesOfLatinLetters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int letters = int.Parse(Console.ReadLine());
            for (int i = 0; i < letters; i++)
            {
                for (int j = 0; j < letters; j++)
                {
                    for (int k = 0; k < letters; k++)
                    {
                        char letter1 = (char) (i + 97);
                        char letter2 = (char) (j + 97);
                        char letter3 = (char) (k + 97);
                        Console.WriteLine($"{letter1}{letter2}{letter3}");
                    }
                }
            }
        }
    }
}
