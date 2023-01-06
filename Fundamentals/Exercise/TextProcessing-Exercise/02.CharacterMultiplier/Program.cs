using System;

namespace _02.CharacterMultiplier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            string one = input[0];
            string two = input[1];
            int sum = 0;
            if (one.Length > two.Length)
            {
                sum = MultiplyAndAddValue(one, two);
            } else
            {
                sum = MultiplyAndAddValue(two, one);
            }
            Console.WriteLine(sum);
        }
        static int MultiplyAndAddValue (string longerString, string shorterString)
        {
            int sum = 0;
            for (int i = 0; i < shorterString.Length; i++)
            {
                int valueOne = shorterString[i];
                int valueTwo = longerString[i];
                sum += valueOne * valueTwo;
            }
            for (int i = shorterString.Length; i < longerString.Length; i++)
            {
                sum += longerString[i];
            }
            return sum;
        }
    }
}
