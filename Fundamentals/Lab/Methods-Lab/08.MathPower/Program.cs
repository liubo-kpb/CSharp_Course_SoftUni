using System;

namespace _08.MathPower
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double basE = double.Parse(Console.ReadLine());
            int power = int.Parse(Console.ReadLine());
            Console.WriteLine(Pow(basE, power));
        }

        static double Pow(double basE, int power)
        {
            return Math.Pow(basE, power);
        }
    }
}
