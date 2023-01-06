using System;

namespace _07.TrekkingMania
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int groups = int.Parse(Console.ReadLine());

            double musala = 0.00;
            double monblan = 0.00;
            double kilimandzharo = 0.00;
            double k2 = 0.00;
            double everest = 0.00;

            int sumPeople = 0;
            for (int i = 0; i < groups; i++)
            {
                int people = int.Parse(Console.ReadLine());
                sumPeople += people;

                if (people < 6)
                {
                    musala += people;
                } else if (people < 13)
                {
                    monblan += people;
                } else if (people < 26)
                {
                    kilimandzharo += people;
                } else if (people < 41)
                {
                    k2 += people;
                } else if (people >= 41)
                {
                    everest += people;
                }
            }

            Console.WriteLine($"{ musala/ sumPeople * 100:f2}%");
            Console.WriteLine($"{ monblan / sumPeople * 100:f2}%");
            Console.WriteLine($"{ kilimandzharo / sumPeople * 100:f2}%");
            Console.WriteLine($"{ k2 / sumPeople * 100:f2}%");
            Console.WriteLine($"{ everest / sumPeople * 100:f2}%");
        }
    }
}
