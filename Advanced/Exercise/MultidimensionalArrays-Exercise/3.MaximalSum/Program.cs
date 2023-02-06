using System;
using System.Linq;

namespace _3.MaximalSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];
            int[,] matrix = new int[rows, cols];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] values = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = values[j];
                }
            }

            int subMatrixSum = 0;
            int subRow = 0;
            int subCol = 0;
            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    int currentSum = 0;
                    for (int i = row; i < row + 3; i++)
                    {
                        for (int k = col; k < col + 3; k++)
                        {
                            currentSum += matrix[i, k];
                        }
                    }
                    if (currentSum > subMatrixSum)
                    {
                        subMatrixSum = currentSum;
                        subRow = row;
                        subCol = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {subMatrixSum}");
            for (int row = subRow; row < subRow + 3; row++)
            {
                for (int col = subCol; col < subCol + 3; col++)
                {
                    Console.Write(matrix[row,col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
