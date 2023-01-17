using System;
using System.Collections.Generic;

namespace _4.MatchingBrackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] chars = Console.ReadLine().ToCharArray();
            Stack<int> startIndexes = new Stack<int>();

            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] == '(')
                {
                    startIndexes.Push(i);
                }
                else if (chars[i] == ')')
                {
                    for (int j = startIndexes.Pop(); j <= i; j++)
                    {
                        Console.Write(chars[j]);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
