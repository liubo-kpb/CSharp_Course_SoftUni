using System;
using System.Linq;

namespace _1._SumMatrixElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] info = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = info[0];
            int columns = info[1];

            int[][] matrix = new int[rows][];
            int sum = 0;
            for (int i = 0; i < rows; i++)
            {
                int[] array = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                matrix[i] = array;
                for (int j = 0; j < array.Length; j++)
                {
                    sum += matrix[i][j];
                }
            }
            Console.WriteLine(rows);
            Console.WriteLine(columns);
            Console.WriteLine(sum);
        }
    }
}
