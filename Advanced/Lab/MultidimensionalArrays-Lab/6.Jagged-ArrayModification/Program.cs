using System;
using System.Linq;

namespace _6.Jagged_ArrayModification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] matrix = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                int[] array = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                matrix[i] = array;
            }

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] command = input.Split(' ');
                string action = command[0];
                int row = int.Parse(command[1]);
                int col = int.Parse(command[2]);
                int value = int.Parse(command[3]);

                if (row < 0 || col < 0 || row >= matrix.Length || col >= matrix[row].Length)
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;
                }

                switch (action)
                {
                    case "Add":
                        matrix[row][col] += value;
                        break;
                    case "Subtract":
                        matrix[row][col] -= value;
                        break;
                }
            }

            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine(string.Join(" ", matrix[i]));
            }
        }
    }
}
