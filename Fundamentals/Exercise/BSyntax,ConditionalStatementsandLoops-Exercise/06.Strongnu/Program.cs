using System;

namespace _06.Strongnu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            int strong = 0;
            int num = input;
            while (num > 0)
            {
                int singleNum = num % 10;
                int facturiel = 1;
                for (int j = 1; j <= singleNum; j++)
                {
                    facturiel *= j;
                }
                strong += facturiel;
                num /= 10;
            }

            if (strong == input)
            {
                Console.WriteLine("yes");
            } else
            {
                Console.WriteLine("no");
            }
        }
    }
}
