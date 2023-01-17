using System;
using System.Collections.Generic;

namespace _09.SimpleTextEditor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int operations = int.Parse(Console.ReadLine());
            Queue<char> chars = new Queue<char>();
            Stack<Queue<char>> backUp = new Stack<Queue<char>>();

            for (int i = 0; i < operations; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int operaction = int.Parse(input[0]);

                switch (operaction)
                {
                    case 1:
                        backUp.Push(BackUp(chars));
                        string someString = input[1];

                        for (int j = 0; j < someString.Length; j++)
                        {
                            chars.Enqueue(someString[j]);
                        }
                        break;
                    case 2:
                        backUp.Push(BackUp(chars));
                        int count = chars.Count - int.Parse(input[1]);

                        for (int j = 0; j < chars.Count; j++)
                        {
                            char ch = chars.Dequeue();
                            if (j < count)
                            {
                                chars.Enqueue(ch);
                            }
                            else
                            {
                                --j;
                            }
                        }
                        break;
                    case 3:
                        int index = int.Parse(input[1]);

                        for (int j = 1; j <= chars.Count; j++)
                        {
                            if (j == index)
                            {
                                Console.WriteLine(chars.Peek());
                            }
                            char ch = chars.Dequeue();
                            chars.Enqueue(ch);
                        }
                        break;
                    case 4:
                        if (backUp.Count > 0)
                        {
                            chars = backUp.Pop();
                        }
                        break;
                }
            }
        }

        static Queue<char> BackUp(Queue<char> chars)
        {
            var temp = new Queue<char>();
            for (int i = 0; i < chars.Count; i++)
            {
                temp.Enqueue(chars.Peek());
                char c = chars.Dequeue();
                chars.Enqueue(c);
            }

            return temp;
        }
    }
}
