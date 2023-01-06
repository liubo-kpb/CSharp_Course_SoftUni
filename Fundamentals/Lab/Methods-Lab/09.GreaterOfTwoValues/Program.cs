using System;

namespace _09.GreaterOfTwoValues
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            switch (type)
            {
                case "int":
                    Console.WriteLine(GetMax(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine())));
                    break;
                case "char":
                    Console.WriteLine(GetMax(char.Parse(Console.ReadLine()), char.Parse(Console.ReadLine())));
                    break;
                case "string":
                    Console.WriteLine(GetMax(Console.ReadLine(), Console.ReadLine()));
                    break;
            }
        }

        static char GetMax(char num1, char num2)
        {
            char max = ' ';
            if (num1 > num2)
            {
                max = num1;
            }
            else
            {
                max = num2;
            }

            return max;
        }
        static int GetMax(int num1, int num2)
        {
            int max = 0;
            if (num1 > num2)
            {
                max = num1;
            }
            else
            {
                max = num2;
            }

            return max;
        }
        static string GetMax(string str1, string str2)
        {
            string max = "";
            if (str1.CompareTo(str2) > 0)
            {
                max = str1;
            }
            else
            {
                max = str2;
            }

            return max;
        }
    }
}
