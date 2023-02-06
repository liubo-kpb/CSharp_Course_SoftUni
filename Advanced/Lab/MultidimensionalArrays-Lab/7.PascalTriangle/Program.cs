using System;

namespace _7.PascalTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long rows = int.Parse(Console.ReadLine());
            long[][] jaggedArray = new long[rows][];
            

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                jaggedArray[i] = new long[i + 1];
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        jaggedArray[i][j] = 1;
                    }
                    else if (j == 0)
                    {
                        jaggedArray[i][j] = jaggedArray[i - 1][j]; // i.e. alwasy equals 1
                    }
                    else if (j == jaggedArray[i - 1].Length)
                    {
                        jaggedArray[i][j] = 1;
                    }
                    else
                    {
                        jaggedArray[i][j] = jaggedArray[i - 1][j - 1] + jaggedArray[i - 1][j];
                    }
                }
                Console.WriteLine(string.Join(" ", jaggedArray[i]));
            }
        }
    }
}
