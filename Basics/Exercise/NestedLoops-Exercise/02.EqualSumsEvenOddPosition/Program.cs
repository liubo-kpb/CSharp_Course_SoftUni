using System;

namespace _02.EqualSumsEvenOddPosition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int smallNum = int.Parse(Console.ReadLine());
            int bigNum = int.Parse(Console.ReadLine());

            for (int i = smallNum; i <= bigNum; i++)
            {
                string numString = $"{i}";
                int evenSum = 0;
                int oddSum = 0;

                for (int j = 0; j < 6; j++)
                {
                    int positionNum = (int) numString[j];
                    if (j % 2 == 0)
                    {
                        evenSum += positionNum;
                    } else
                    {
                        oddSum += positionNum;
                    }
                }

                if (evenSum == oddSum)
                {
                    Console.Write($"{numString} ");
                }
            }
        }
    }
}
