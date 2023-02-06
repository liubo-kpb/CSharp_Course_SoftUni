using System;
using System.Linq;

namespace _10.RadioactiveMutantVampireBunnies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];
            char[,] matrix = new char[rows, cols];

            int[] playerPosition = new int[2];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string value = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = value[col];
                    if (matrix[row, col] == 'P')
                    {
                        playerPosition = new int[2] { row, col };
                    }
                }
            }

            string moves = Console.ReadLine();
            for (int i = 0; i < moves.Length; i++)
            {
                int playerStatus = MovePlayer(ref playerPosition, ref matrix, moves[i]);
                int bunnyAction = SpreadBunnies(ref matrix);

                if (playerStatus == 1)
                {
                    PrintMatrix(matrix);
                    Console.WriteLine($"won: {playerPosition[0]} {playerPosition[1]}");

                    return;
                }
                else if (playerStatus == 2 || bunnyAction == 1)
                {
                    PrintMatrix(matrix);
                    Console.WriteLine($"dead: {playerPosition[0]} {playerPosition[1]}");

                    return;
                }
            }
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static int SpreadBunnies(ref char[,] matrix)
        {

            int bunnies = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        bunnies++;
                    }
                }
            }

            int[][] bunnyLocations = new int[bunnies][];
            int bunnyRow = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        bunnyLocations[bunnyRow++] = new int[2] { row, col };
                    }
                }
            }

            int result = 0;
            for (int bunny = 0; bunny < bunnyLocations.GetLength(0); bunny++)
            {
                for (int i = bunnyLocations[bunny][0] - 1; i <= bunnyLocations[bunny][0] + 1; i += 2)
                {
                    if (IsValidCell(i, bunnyLocations[bunny][1], matrix) && matrix[i, bunnyLocations[bunny][1]] == 'P')
                    {
                        matrix[i, bunnyLocations[bunny][1]] = 'B';
                        result = 1;
                    }
                    else if (IsValidCell(i, bunnyLocations[bunny][1], matrix) && matrix[i, bunnyLocations[bunny][1]] == '.')
                    {
                        matrix[i, bunnyLocations[bunny][1]] = 'B';
                    }
                }
                for (int k = bunnyLocations[bunny][1] - 1; k <= bunnyLocations[bunny][1] + 1; k += 2)
                {
                    if (IsValidCell(bunnyLocations[bunny][0], k, matrix) && matrix[bunnyLocations[bunny][0], k] == 'P')
                    {
                        matrix[bunnyLocations[bunny][0], k] = 'B';
                        result = 1;
                    }
                    else if (IsValidCell(bunnyLocations[bunny][0], k, matrix) && matrix[bunnyLocations[bunny][0], k] == '.')
                    {
                        matrix[bunnyLocations[bunny][0], k] = 'B';
                    }
                }
            }

            return result;
        }

        private static int MovePlayer(ref int[] playerPosition, ref char[,] matrix, char move)
        {
            switch (move)
            {
                case 'L':
                    if (IsValidCell(playerPosition[0], playerPosition[1] - 1, matrix) && matrix[playerPosition[0], playerPosition[1] - 1] == 'B')
                    {
                        playerPosition[1]--;
                        return 2;
                    }
                    else if ((IsValidCell(playerPosition[0], playerPosition[1] - 1, matrix) && matrix[playerPosition[0], playerPosition[1] - 1] == '.'))
                    {
                        matrix[playerPosition[0], playerPosition[1]--] = '.';
                        matrix[playerPosition[0], playerPosition[1]] = 'P';
                        return 0;
                    }
                    else
                    {
                        matrix[playerPosition[0], playerPosition[1]] = '.';
                        return 1;
                    }
                case 'R':
                    if (IsValidCell(playerPosition[0], playerPosition[1] + 1, matrix) && matrix[playerPosition[0], playerPosition[1] + 1] == 'B')
                    {
                        playerPosition[1]++;
                        return 2;
                    }
                    else if ((IsValidCell(playerPosition[0], playerPosition[1] + 1, matrix) && matrix[playerPosition[0], playerPosition[1] + 1] == '.'))
                    {
                        matrix[playerPosition[0], playerPosition[1]++] = '.';
                        matrix[playerPosition[0], playerPosition[1]] = 'P';

                        return 0;
                    }
                    else
                    {
                        matrix[playerPosition[0], playerPosition[1]] = '.';
                        return 1;
                    }
                case 'U':
                    if (IsValidCell(playerPosition[0] - 1, playerPosition[1], matrix) && matrix[playerPosition[0] - 1, playerPosition[1]] == 'B')
                    {
                        playerPosition[0]--;
                        return 2;
                    }
                    else if ((IsValidCell(playerPosition[0] - 1, playerPosition[1], matrix) && matrix[playerPosition[0] - 1, playerPosition[1]] == '.'))
                    {
                        matrix[playerPosition[0]--, playerPosition[1]] = '.';
                        matrix[playerPosition[0], playerPosition[1]] = 'P';
                        return 0;
                    }
                    else
                    {
                        matrix[playerPosition[0], playerPosition[1]] = '.';
                        return 1;
                    }
                case 'D':
                    if (IsValidCell(playerPosition[0] + 1, playerPosition[1], matrix) && matrix[playerPosition[0] + 1, playerPosition[1]] == 'B')
                    {
                        playerPosition[0]++;
                        return 2;
                    }
                    else if ((IsValidCell(playerPosition[0] + 1, playerPosition[1], matrix) && matrix[playerPosition[0] + 1, playerPosition[1]] == '.'))
                    {
                        matrix[playerPosition[0]++, playerPosition[1]] = '.';
                        matrix[playerPosition[0], playerPosition[1]] = 'P';
                        return 0;
                    }
                    else
                    {
                        matrix[playerPosition[0], playerPosition[1]] = '.';
                        return 1;
                    }
            }

            return 0;
        }

        private static bool IsValidCell(int row, int col, char[,] matrix)
        {
            return row >= 0 && col >= 0 && row < matrix.GetLength(0) && col < matrix.GetLength(1);
        }
    }
}
