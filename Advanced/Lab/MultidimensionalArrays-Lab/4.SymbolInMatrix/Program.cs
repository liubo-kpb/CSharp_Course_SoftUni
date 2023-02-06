using System;
using System.Linq;

namespace _4.SymbolInMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] chars = new char[size, size];

            for (int i = 0; i < size; i++)
            {
                string line = Console.ReadLine();
                for (int j = 0; j < size; j++)
                {
                    chars[i, j] = line[j];
                }
            }
            char symbol =  char.Parse(Console.ReadLine());

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (chars[i,j] == symbol)
                    {
                        Console.WriteLine($"({i}, {j})");
                        return;
                    }
                }
            }

            Console.WriteLine($"{symbol} does not occur in the matrix");
        }
    }
}
