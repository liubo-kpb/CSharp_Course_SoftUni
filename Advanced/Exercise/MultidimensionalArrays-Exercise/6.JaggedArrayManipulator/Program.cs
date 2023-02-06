using System;
using System.Linq;

namespace _6.JaggedArrayManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] jaggedArray = new int[rows][];

            for (int i = 0; i < jaggedArray.GetLength(0); i++)
            {
                jaggedArray[i] = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }

            for (int row = 0; row < jaggedArray.GetLength(0) - 1; row++)
            {
                if (jaggedArray[row].Length == jaggedArray[row + 1].Length)
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        jaggedArray[row][col] *= 2;
                        jaggedArray[row + 1][col] *= 2;
                    }
                }
                else
                {
                    int maxColLength = jaggedArray[row].Length > jaggedArray[row + 1].Length ? jaggedArray[row].Length : jaggedArray[row + 1].Length;
                    for (int col = 0; col < maxColLength; col++)
                    {
                        if (col < jaggedArray[row].Length)
                        {
                            jaggedArray[row][col] /= 2;
                        }
                        if (col < jaggedArray[row + 1].Length)
                        {
                            jaggedArray[row + 1][col] /= 2;
                        }
                    }
                }
            }

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] command = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string action = command[0];
                int row = int.Parse(command[1]);
                int col = int.Parse(command[2]);
                int value = int.Parse(command[3]);

                if (row >= 0 && col >= 0 && row < jaggedArray.GetLength(0) && col < jaggedArray[row].Length)
                {
                    switch (action)
                    {
                        case "Add":
                            jaggedArray[row][col] += value;
                            break;
                        case "Subtract":
                            jaggedArray[row][col] -= value;
                            break;
                    }
                }
            }
            for (int row = 0; row < jaggedArray.GetLength(0); row++)
            {
                Console.WriteLine(string.Join(' ', jaggedArray[row]));
            }
        }
    }
}
