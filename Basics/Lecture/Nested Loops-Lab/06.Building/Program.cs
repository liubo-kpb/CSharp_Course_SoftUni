using System;

namespace _06.Building
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int floors = int.Parse(Console.ReadLine());
            int accomodations = int.Parse(Console.ReadLine());

            for (int i = floors; i > 0; i--)
            {
                for (int a = 0; a < accomodations; a++)
                {
                    if (i == floors)
                    {
                        Console.Write($"L{i}{a} ");
                    } else if (i % 2 == 1)
                    {
                        Console.Write($"A{i}{a} ");
                    } else
                    {
                        Console.Write($"O{i}{a} ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
