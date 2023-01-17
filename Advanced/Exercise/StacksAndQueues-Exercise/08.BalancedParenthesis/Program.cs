using System;
using System.Collections.Generic;

namespace _08.BalancedParenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> stack = new Stack<char>();


            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                if (c == '(' || c == '[' || c == '{')
                {
                    stack.Push(c);
                }
                else if (stack.Count == 0)
                {
                    Console.WriteLine("NO");
                    return;
                }
                else
                {
                    switch (c)
                    {
                        case ')':
                            if (stack.Peek() == '(')
                            {
                                stack.Pop();
                                continue;
                            }
                            break;
                        case ']':
                            if (stack.Peek() == '[')
                            {
                                stack.Pop();
                                continue;
                            }
                            break;
                        case '}':
                            if (stack.Peek() == '{')
                            {
                                stack.Pop();
                                continue;
                            }
                            break;
                    }
                    Console.WriteLine("NO");
                    return;
                }
            }
            Console.WriteLine("YES");
        }
    }
}