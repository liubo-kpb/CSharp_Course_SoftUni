using System;

namespace _10.LowerOrUpper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char symbol = char.Parse(Console.ReadLine());
            if (symbol < 91)
            {
                Console.WriteLine("upper-case");
            } else if (symbol > 96)
            {
                Console.WriteLine("lower-case");
            }
        }
    }
}
