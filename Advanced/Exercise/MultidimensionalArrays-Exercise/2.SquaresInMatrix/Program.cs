using System;
using System.Linq;

namespace _2.SquaresInMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];
            char[,] matrix = new char[rows, cols];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] values = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = values[j];
                }
            }

            int equalSubMatrisies = 0;
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    char currentChar = matrix[row, col];
                    if (currentChar == matrix[row + 1, col]
                        && currentChar == matrix[row, col + 1]
                        && currentChar == matrix[row + 1, col + 1])
                    {
                        equalSubMatrisies++;
                    }
                }
            }
            Console.WriteLine(equalSubMatrisies);
        }
    }
}
