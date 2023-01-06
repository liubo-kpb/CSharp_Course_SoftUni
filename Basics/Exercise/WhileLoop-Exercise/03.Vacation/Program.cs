using System;

namespace _03.Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double moneyForVacation = double.Parse(Console.ReadLine());
            double moneyPresent = double.Parse(Console.ReadLine()); ;

            int days = 0;
            int spent = 0;

            while (moneyPresent < moneyForVacation && spent < 5)
            {
                string action = Console.ReadLine();
                double sum = double.Parse(Console.ReadLine());
                days++;

                if (action == "spend")
                {
                    moneyPresent -= sum;
                    spent++;

                    if (moneyPresent < 0)
                    {
                        moneyPresent = 0;
                    }
                }
                else
                {
                    moneyPresent += sum;
                    spent = 0;
                }
            }

            if (spent == 5 || moneyPresent < moneyForVacation)
            {
                Console.WriteLine("You can't save the money.");
                Console.WriteLine(days);
            } else
            {
                Console.WriteLine($"You saved the money for {days} days.");
            }
        }
    }
}
