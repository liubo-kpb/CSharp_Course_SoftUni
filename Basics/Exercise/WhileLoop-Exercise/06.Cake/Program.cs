using System;

namespace _06.Cake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int cakeW = int.Parse(Console.ReadLine());
            int cakeL = int.Parse(Console.ReadLine());

            int cake = cakeL * cakeW;
            string command = Console.ReadLine();
            while (command != "STOP")
            {
                int pieces = int.Parse(command);
                cake -= pieces;

                if (cake < 0)
                {
                    break;
                }

                command = Console.ReadLine();
            }

            if (command == "STOP")
            {
                Console.WriteLine($"{cake} pieces are left.");
            } else
            {
                Console.WriteLine($"No more cake left! You need {Math.Abs(cake)} pieces more.");
            }
        }
    }
}
