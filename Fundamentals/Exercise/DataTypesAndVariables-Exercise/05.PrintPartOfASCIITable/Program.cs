using System;

namespace _05.PrintPartOfASCIITable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int startIndex = int.Parse(Console.ReadLine());
            int endIndex = int.Parse(Console.ReadLine());

            for (char index = (char) startIndex; index <= endIndex; index++)
            {
                Console.Write(index + " ");
            }
        }
    }
}
