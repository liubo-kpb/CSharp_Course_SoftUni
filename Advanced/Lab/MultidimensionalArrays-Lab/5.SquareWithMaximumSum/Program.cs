using System;
using System.Linq;

namespace _5.SquareWithMaximumSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");
            int row = int.Parse(input[0]);
            int col = int.Parse(input[1]);

            int[,] matrix = new int[row, col];
            for (int i = 0; i < row; i++)
            {
                int[] line = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int j = 0; j < col; j++)
                {
                    matrix[i, j] = line[j];
                }
            }

            int subMatrixSum = 0;
            int subMatrixRow = 0;
            int subMatrixCol = 0;
            for (int i = 0; i < col - 1; i++)
            {
                for (int j = 0; j < row - 1; j++)
                {
                    int currentSum = matrix[j, i] + matrix[j, i + 1]
                                   + matrix[j + 1, i] + matrix[j + 1, i + 1];
                    if (currentSum > subMatrixSum)
                    {
                        subMatrixSum = currentSum;
                        subMatrixRow = j;
                        subMatrixCol = i;
                    }
                }
            }

            Console.WriteLine($"{matrix[subMatrixRow, subMatrixCol]} {matrix[subMatrixRow, subMatrixCol + 1]} {Environment.NewLine + matrix[subMatrixRow + 1, subMatrixCol]} {matrix[subMatrixRow + 1, subMatrixCol + 1]}");
            Console.WriteLine(subMatrixSum);
        }
    }
}
