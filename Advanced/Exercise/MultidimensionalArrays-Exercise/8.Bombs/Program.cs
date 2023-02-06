using System;
using System.Drawing;
using System.Linq;

namespace _8.Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[,] matrix = new int[rows, rows];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] values = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = values[j];
                }
            }

            string[] bombCoordinates = Console.ReadLine().Split();
            int[][] bombs = new int[bombCoordinates.Length][];
            for (int i = 0; i < bombCoordinates.Length; i++)
            {
                bombs[i] = bombCoordinates[i].Split(',').Select(int.Parse).ToArray();
            }

            for (int i = 0; i < bombs.GetLength(0); i++)
            {
                int bombRow = bombs[i][0];
                int bombCol = bombs[i][1];
                int currentBomb = matrix[bombRow, bombCol];

                if (currentBomb <= 0)
                {
                    continue;
                }

                BombCells(bombRow, bombCol, currentBomb, ref matrix);
                matrix[bombRow, bombCol] = 0;
            }

            int livingCells = 0;
            int aliveSum = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        livingCells++;
                        aliveSum += matrix[row, col];
                    }
                }
            }
            Console.WriteLine($"Alive cells: {livingCells}");
            Console.WriteLine($"Sum: {aliveSum}");

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void BombCells(int bombRow, int bombCol, int currentBomb, ref int[,] matrix)
        {
            if (IsCellValid(bombRow - 1, bombCol - 1, matrix) && matrix[bombRow - 1, bombCol - 1] > 0)
            {
                matrix[bombRow - 1, bombCol - 1] -= currentBomb;
            }

            if (IsCellValid(bombRow - 1, bombCol, matrix) && matrix[bombRow - 1, bombCol] > 0)
            {
                matrix[bombRow - 1, bombCol] -= currentBomb;
            }

            if (IsCellValid(bombRow - 1, bombCol + 1, matrix) && matrix[bombRow - 1, bombCol + 1] > 0)
            {
                matrix[bombRow - 1, bombCol + 1] -= currentBomb;
            }

            if (IsCellValid(bombRow, bombCol - 1, matrix) && matrix[bombRow, bombCol - 1] > 0)
            {
                matrix[bombRow, bombCol - 1] -= currentBomb;
            }

            if (IsCellValid(bombRow, bombCol + 1, matrix) && matrix[bombRow, bombCol + 1] > 0)
            {
                matrix[bombRow, bombCol + 1] -= currentBomb;
            }

            if (IsCellValid(bombRow + 1, bombCol - 1, matrix) && matrix[bombRow + 1, bombCol - 1] > 0)
            {
                matrix[bombRow + 1, bombCol - 1] -= currentBomb;
            }

            if (IsCellValid(bombRow + 1, bombCol, matrix) && matrix[bombRow + 1, bombCol] > 0)
            {
                matrix[bombRow + 1, bombCol] -= currentBomb;
            }

            if (IsCellValid(bombRow + 1, bombCol + 1, matrix) && matrix[bombRow + 1, bombCol + 1] > 0)
            {
                matrix[bombRow + 1, bombCol + 1] -= currentBomb;
            }
        }

        private static bool IsCellValid(int row, int col, int[,] matrix)
        {
            return row >= 0 && col >= 0 && row < matrix.GetLength(0) && col < matrix.GetLength(1);
        }
    }
}
