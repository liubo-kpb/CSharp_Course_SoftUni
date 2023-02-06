using System;
using System.Linq;

namespace _7.KnightGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            if (rows < 3)
            {
                Console.WriteLine(0);
                return;
            }

            char[,] chessBoard = new char[rows, rows];

            for (int i = 0; i < chessBoard.GetLength(0); i++)
            {
                string values = Console.ReadLine();
                for (int j = 0; j < chessBoard.GetLength(1); j++)
                {
                    chessBoard[i, j] = values[j];
                }
            }

            int removedKnights = 0;
            bool canAttack = true;
            while (canAttack)
            {
                int[] attackingKnight = new int[2];
                int mostAttacking = 0;

                for (int row = 0; row < chessBoard.GetLength(0); row++)
                {
                    for (int col = 0; col < chessBoard.GetLength(1); col++)
                    {
                        if (chessBoard[row, col] == '0')
                        {
                            continue;
                        }

                        int possibleAttacks = FindAttackingOptions(row, col, chessBoard.GetLength(0), chessBoard);
                        if (possibleAttacks > mostAttacking)
                        {
                            mostAttacking = possibleAttacks;
                            attackingKnight = new int[] { row, col };
                        }
                    }
                }

                if (mostAttacking == 0)
                {
                    canAttack = false;
                }
                else
                {
                    chessBoard[attackingKnight[0], attackingKnight[1]] = '0';
                    removedKnights++;
                }
            }
            Console.WriteLine(removedKnights);
        }

        private static int FindAttackingOptions(int row, int col, int size, char[,] board)
        {
            int possibleAttacks = 0;

            if (IsValidCell(row - 2, col - 1, size) && board[row - 2, col - 1] == 'K')
            {
                possibleAttacks++;
            }

            if (IsValidCell(row - 2, col + 1, size) && board[row - 2, col + 1] == 'K')
            {
                possibleAttacks++;
            }

            if (IsValidCell(row + 2, col - 1, size) && board[row + 2, col - 1] == 'K')
            {
                possibleAttacks++;
            }

            if (IsValidCell(row + 2, col + 1, size) && board[row + 2, col + 1] == 'K')
            {
                possibleAttacks++;
            }

            if (IsValidCell(row - 1, col - 2, size) && board[row - 1, col - 2] == 'K')
            {
                possibleAttacks++;
            }

            if (IsValidCell(row - 1, col + 2, size) && board[row - 1, col + 2] == 'K')
            {
                possibleAttacks++;
            }

            if (IsValidCell(row + 1, col + 2, size) && board[row + 1, col + 2] == 'K')
            {
                possibleAttacks++;
            }

            if (IsValidCell(row + 1, col - 2, size) && board[row + 1, col - 2] == 'K')
            {
                possibleAttacks++;
            }

            return possibleAttacks;
        }

        private static bool IsValidCell(int row, int col, int size)
        {
            return row >= 0 && col >= 0 && row < size && col < size;
        }
    }
}
