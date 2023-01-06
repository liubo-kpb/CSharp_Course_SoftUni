using System;

namespace _01.ExcellentResult
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double cGrade = double.Parse(Console.ReadLine());
            if (cGrade >= 5.5)
            {
                Console.WriteLine("Excellent!");
            }
        }
    }
}
