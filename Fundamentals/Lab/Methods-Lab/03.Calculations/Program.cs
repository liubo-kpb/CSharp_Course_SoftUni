using System;

namespace _03.Calculations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            switch (command)
            {
                case "add":
                    Add(num1, num2);
                    break;
                case "multiply":
                    Multiply(num1, num2);
                    break;
                case "substract":
                    Substract(num1, num2);
                    break;
                case "divide":
                    Divide(num1, num2);
                    break;
            }
        }

        static void Divide(int num1, int num2)
        {
            Console.WriteLine(num1 / num2);
        }
        static void Substract(int num1, int num2)
        {
            Console.WriteLine(num1 - num2);
        }
        static void Multiply(int num1, int num2)
        {
            Console.WriteLine(num1 * num2);
        }
        static void Add(int num1, int num2)
        {
            Console.WriteLine(num2 + num1);
        }
    }
}
