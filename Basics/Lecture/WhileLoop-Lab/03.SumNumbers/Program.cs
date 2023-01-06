using System;

namespace _06.MaxNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int converter = 0;
            int minValue = int.MaxValue;

            while (command != "Stop")
            {
                converter = int.Parse(command);
                if (minValue > converter)
                {
                    minValue = converter;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(minValue);
        }
    }
}
