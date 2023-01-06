using System;

namespace _06.MaxNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int converter = 0;
            int maxValue = int.MinValue;

            while (command != "Stop")
            {
                converter = int.Parse(command);
                if (maxValue < converter)
                {
                    maxValue = converter;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(maxValue);
        }
    }
}
