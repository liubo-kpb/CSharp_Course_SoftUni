using System;

namespace _03.CharactersInRange
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char startChr = char.Parse(Console.ReadLine());
            char endChr = char.Parse(Console.ReadLine());

            if (startChr > endChr)
            {
                char currentChr = startChr;
                startChr = endChr;
                endChr = currentChr;
            }

            PrintCharsInbetwee(startChr, endChr);
        }

        static void PrintCharsInbetwee (char startChr, char endChr)
        {
            for (char i = ++startChr; i < endChr; i++)
            {
                Console.Write(i + " ");
            }
        }
    }
}
