using System;
using System.Linq;

namespace _01.ReverseStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end")
            {
                char[] reversedString = input.Reverse().ToArray();
                Console.WriteLine($"{input} = {string.Join("",reversedString)}");
            }
        }
    }
}
