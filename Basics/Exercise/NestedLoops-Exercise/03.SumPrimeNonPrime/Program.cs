using System;

namespace _03.SumPrimeNonPrime
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            int primeSum = 0;
            int notPrimeSum = 0;
            while (command != "stop")
            {
                int number = int.Parse(command);
                if (number < 0)
                {
                    Console.WriteLine("Number is negative.");
                }
                else if (number == 0);
                else
                {
                    bool isPrime = true;
                    int primeCheck = number / 2;
                    for (int i = 2; i <= primeCheck; i++)
                    {
                        if (number % i == 0)
                        {
                            notPrimeSum += number;
                            isPrime = false;
                            break;
                        } 
                    }
                    if (isPrime)
                    {
                        primeSum += number;
                    }
                }

                command = Console.ReadLine();
            }
            Console.WriteLine($"Sum of all prime numbers is: {primeSum}");
            Console.WriteLine($"Sum of all non prime numbers is: {notPrimeSum}");
        }
    }
}
