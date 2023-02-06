using System;
using System.Linq;
using System.Text;

namespace _5.SnakeMoves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string snake = Console.ReadLine();

            int rows = input[0];
            int cols = input[1];
            char[,] matrix = new char[rows, cols];

            int startingIndex = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (startingIndex == snake.Length)
                        {
                            startingIndex = 0;
                        }
                        matrix[row, col] = snake[startingIndex++];
                    }
                }
                else if (row % 2 == 1)
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        if (startingIndex == snake.Length)
                        {
                            startingIndex = 0;
                        }
                        matrix[row, col] = snake[startingIndex++];
                    }
                }
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                    Console.WriteLine();
            }
        }
    }
}
