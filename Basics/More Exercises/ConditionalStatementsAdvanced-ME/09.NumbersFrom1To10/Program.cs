using System;

namespace _09.NumbersFrom1To10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 1;
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(a++);
            }
        }
    }
}
