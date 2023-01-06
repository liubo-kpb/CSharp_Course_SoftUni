using System;

namespace _06.Operations_Nums
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double n1 = double.Parse(Console.ReadLine());
            double n2 = double.Parse(Console.ReadLine());
            char operators = char.Parse(Console.ReadLine());

            if ((operators == '/' || operators == '%') && n2 == 0)
            {
                Console.WriteLine($"Cannot divide {n1} by zero");
                System.Environment.Exit(0);
            }

            double result = 0.00;
            switch(operators)
            {
                case '+':
                    result = n1 + n2;
                    Console.Write($"{n1} + {n2} = {result} - ");
                    break;
                case '-':
                    result = n1 - n2;
                    Console.Write($"{n1} - {n2} = {result} - ");
                    break;
                case '*':
                    result = n1 * n2;
                    Console.Write($"{n1} * {n2} = {result} - ");
                    break;
                case '/':
                    result = n1 / n2;
                    Console.WriteLine($"{n1} / { n2} = {result:f2}");
                    break;
                case '%':
                    result = n1 % n2;
                    Console.Write($"{n1} % {n2} = {result}");
                    break;
            }

            if (result % 2 == 0 && operators != '%' && operators != '/')
            {
                Console.WriteLine("even");
            } else if (result % 2 != 0 && operators != '%' && operators != '/')
            {
                Console.WriteLine("odd");
            }
        }
    }
}
