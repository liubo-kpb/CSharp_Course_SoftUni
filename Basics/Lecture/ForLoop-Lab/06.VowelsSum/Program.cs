using System;

namespace _06.VowelsSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int output = 0;
            for (int i = 0; i < input.Length; i++)
            {
                switch (input[i])
                {
                    case 'a':
                        output += 1;
                        break;
                    case 'e':
                        output += 2;
                        break;
                    case 'i':
                        output += 3;
                        break;
                    case 'o':
                        output += 4;
                        break;
                    case 'u':
                        output += 5;
                        break;
                }
            }
            Console.WriteLine(output);
        }
    }
}
