using System;

namespace _02.BonusScore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numP = int.Parse(Console.ReadLine());
            double endP;
            double bonus = 0.0;

            if (numP <= 100)
            {
                bonus = 5;
            } else if (numP > 1000)
            {
                bonus = numP * 0.1;
            } else if (numP > 100)
            {
                bonus = numP * 0.2;
            }

            int isEven = numP % 2;
            if (isEven == 0)
            {
                bonus++;
            } else if((numP % 10) == 5)
            {
                bonus += 2;
            }
            endP = bonus + numP;
            Console.WriteLine(bonus);
            Console.WriteLine(endP);
        }
    }
}
