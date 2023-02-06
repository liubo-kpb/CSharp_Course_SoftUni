using System;
using System.Linq;

namespace _1.DiagonalDifference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[,] matrix = new int[rows, rows];
            int diagonalDifference = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] values = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {

                    matrix[i, j] = values[j];
                    if (i == j)
                    {
                        diagonalDifference += matrix[i, j];
                    }
                    if (i + j == matrix.GetLength(0) - 1)
                    {
                        diagonalDifference -= matrix[i, j];
                    }
                }
            }
            Console.WriteLine(Math.Abs(diagonalDifference));
        }
    }
}
