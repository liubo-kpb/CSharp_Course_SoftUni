using System;

namespace _05.SpecialNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 1111; i <= 9999; i++)
            {
                bool isSpecial = true;

                for (int j = 0; j < 4; j++)
                {
                    string numberToString = $"{i}";
                    char symbol = numberToString[j];
                    string symbolOnJ = $"{symbol}";
                    int numOnJ = int.Parse(symbolOnJ);

                    if (numOnJ == 0 || number % numOnJ != 0)
                    {
                        isSpecial = false;
                        break;
                    }
                }

                if (isSpecial)
                {
                    Console.Write($"{i} ");
                }
            }
        }
    }
}
