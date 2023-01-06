using System;

namespace _03.DepositCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Input
            double depositSum = double.Parse(Console.ReadLine());
            int months = int.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine()) / 100;

            //Calculation
            double sum = depositSum + months * ((depositSum * percent) / 12);

            //Output
            Console.WriteLine(sum);
        }
    }
}
