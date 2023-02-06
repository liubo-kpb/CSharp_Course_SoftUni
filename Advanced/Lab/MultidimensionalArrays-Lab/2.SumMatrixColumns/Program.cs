using System;
using System.Linq;

namespace _2.SumMatrixColumns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");
            int row = int.Parse(input[0]);
            int col = int.Parse(input[1]);

            int[,] values = new int[row, col];
            for (int i = 0; i < row; i++)
            {
                int[] line = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int j = 0; j < col; j++)
                {
                    values[i,j] = line[j];
                }
            }

            for (int i = 0; i < col; i++)
            {
                int sum = 0;
                for (int j = 0; j < row; j++)
                {
                    sum += values[j, i];
                }
                Console.WriteLine(sum);
            }
        }
    }
}
