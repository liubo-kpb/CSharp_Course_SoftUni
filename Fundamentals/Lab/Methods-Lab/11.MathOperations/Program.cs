using System;

namespace _11.MathOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double num1 = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            double num2 = int.Parse(Console.ReadLine());

            double result = 0;
            switch (input)
            {
                case "+":
                    result = Add(num1, num2);
                    break;
                case "*":
                    result = Multiply(num1, num2);
                    break;
                case "-":
                    result = Substract(num1, num2);
                    break;
                case "/":
                    result = Divide(num1, num2);
                    break;
            }

            Console.WriteLine(result);
        }

        static double Divide(double num1, double num2)
        {
            return (num1 / num2);
        }
        static double Substract(double num1, double num2)
        {
            return (num1 - num2);
        }
        static double Multiply(double num1, double num2)
        {
            return (num1 * num2);
        }
        static double Add(double num1, double num2)
        {
            return (num2 + num1);
        }
    }
}
