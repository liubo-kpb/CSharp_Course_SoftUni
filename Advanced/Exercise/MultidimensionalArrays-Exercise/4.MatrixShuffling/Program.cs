using System;
using System.Linq;

namespace _4.MatrixShuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];
            string[,] matrix = new string[rows, cols];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string[] values = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = values[j];
                }
            }

            string input2 = string.Empty;
            while ((input2 = Console.ReadLine()) != "END")
            {
                string[] command = input2.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (command.Length > 5
                    || command[0] != "swap"
                    || int.Parse(command[1]) < 0 || int.Parse(command[1]) >= matrix.GetLength(0)
                    || int.Parse(command[2]) < 0 || int.Parse(command[2]) >= matrix.GetLength(1)
                    || int.Parse(command[3]) < 0 || int.Parse(command[3]) >= matrix.GetLength(0)
                    || int.Parse(command[4]) < 0 || int.Parse(command[4]) >= matrix.GetLength(1)
                    )
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                int row1 = int.Parse(command[1]);
                int col1 = int.Parse(command[2]);
                int row2 = int.Parse(command[3]);
                int col2 = int.Parse(command[4]);

                string oldValue = matrix[row1, col1];
                matrix[row1, col1] = matrix[row2, col2];
                matrix[row2, col2] = oldValue;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        Console.Write(matrix[row, col] + " ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
