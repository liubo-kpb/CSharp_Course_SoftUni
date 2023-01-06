using System;
using System.Linq;
using System.Collections.Generic;

namespace _05.BombNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int[] bomb = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int bombNumber = bomb[0];
            int detonationPower = bomb[1];

            while (numbers.Contains(bombNumber))
            {
                int index = numbers.IndexOf(bombNumber);
                int leftDesolation = index - detonationPower;
                if (leftDesolation < 0)
                {
                    leftDesolation = 0;
                }
                for(int i = index; i >= leftDesolation; i--)
                {
                    if (numbers[i] - bombNumber <= 0)
                    {
                        numbers.RemoveAt(i);
                        i++;
                        leftDesolation++;
                        index--;
                    }
                }
                int rightDesolation = index + detonationPower;
                if (rightDesolation >= numbers.Count)
                {
                    rightDesolation = numbers.Count - 1;
                }
                for (int i = index + 1; i <= rightDesolation; i++)
                {
                    if (numbers[i] - bombNumber <= 0)
                    {
                        numbers.RemoveAt(i);
                        i--;
                        rightDesolation--;
                    }
                }
            }

            Console.WriteLine(numbers.Sum());
        }
    }
}
