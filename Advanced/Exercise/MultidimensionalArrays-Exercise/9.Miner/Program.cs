using System;
using System.Drawing;
using System.Linq;

namespace _9.Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            char[,] field = new char[size, size];

            int coals = 0;
            int[] minerPosition = new int[2];
            for (int i = 0; i < field.GetLength(0); i++)
            {
                char[] values = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    field[i, j] = values[j];
                    if (values[j] == 'c')
                    {
                        coals++;
                    }
                    if (values[j] == 's')
                    {
                        minerPosition = new int[2] { i, j };
                    }
                }
            }

            int collectedCoal = 0;
            for (int i = 0; i < commands.Length; i++)
            {
                string action = commands[i];

                switch (action)
                {
                    case "up":
                        if (IsCellValid(minerPosition[0] - 1, field.GetLength(0)))
                        {
                            collectedCoal += MoveMiner(ref minerPosition, ref field, minerPosition[0] - 1, minerPosition[1]);
                        }
                        break;
                    case "right":
                        if (IsCellValid(minerPosition[1] + 1, field.GetLength(0)))
                        {
                            collectedCoal += MoveMiner(ref minerPosition, ref field, minerPosition[0], minerPosition[1] + 1);
                        }
                        break;
                    case "left":
                        if (IsCellValid(minerPosition[1] - 1, field.GetLength(0)))
                        {
                            collectedCoal += MoveMiner(ref minerPosition, ref field, minerPosition[0], minerPosition[1] - 1);
                        }
                        break;
                    case "down":
                        if (IsCellValid(minerPosition[0] + 1, field.GetLength(0)))
                        {
                            collectedCoal += MoveMiner(ref minerPosition, ref field, minerPosition[0] + 1, minerPosition[1]);
                        }
                        break;
                }
                if (collectedCoal == coals)
                {
                    Console.WriteLine($"You collected all coals! ({minerPosition[0]}, {minerPosition[1]})");
                    return;
                }
            }
            Console.WriteLine($"{coals - collectedCoal} coals left. ({minerPosition[0]}, {minerPosition[1]})");
        }

        private static int MoveMiner(ref int[] minerPosition, ref char[,] field, int newRow, int newCol)
        {
            if (field[newRow, newCol] == 'c')
            {
                field[newRow, newCol] = '*';
                minerPosition[0] = newRow;
                minerPosition[1] = newCol;
                return 1;
            }
            else if (field[newRow, newCol] == 'e')
            {
                Console.WriteLine($"Game over! ({newRow}, {newCol})");
                Environment.Exit(0);
            }
            else
            {
                minerPosition[0] = newRow;
                minerPosition[1] = newCol;
            }
            return 0;
        }

        private static bool IsCellValid(int cell, int size)
        {
            return cell >= 0 && cell < size;
        }
    }
}
