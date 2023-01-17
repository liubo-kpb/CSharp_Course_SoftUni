using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.SimpleCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split().Reverse().ToArray();
            Stack<string> stack = new Stack<string>(input);

            int equation = int.Parse(stack.Pop());
            while (stack.Count > 0)
            {
                char opeartion = char.Parse(stack.Pop());
                int num = int.Parse(stack.Pop());

                switch (opeartion)
                {
                    case '+':
                        equation += num;
                        break;
                    case '-':
                        equation -= num;
                        break;
                }
            }
            Console.WriteLine(equation);
        }
    }
}
