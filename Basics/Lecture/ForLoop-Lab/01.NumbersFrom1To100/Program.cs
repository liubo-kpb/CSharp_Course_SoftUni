using System;

namespace _01.NumbersFrom1To100
{
    internal class Program
    {
        static void Main(string[] args)
        {
                int a = 1;
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine(a++);
                }
            }
        }
    }
