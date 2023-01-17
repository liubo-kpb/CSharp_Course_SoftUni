using System;
using System.Collections.Generic;

namespace _1._Reverse_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();
            Stack<char> stack = new Stack<char>(input.ToCharArray());

            foreach(var ch in stack)
            {
                Console.Write(ch);
            }
        }
    }
}
