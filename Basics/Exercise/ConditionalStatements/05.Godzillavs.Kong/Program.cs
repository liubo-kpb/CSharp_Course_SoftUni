using System;

namespace _05.Godzillavs.Kong
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int people = int.Parse(Console.ReadLine());
            double clothingPrise = double.Parse(Console.ReadLine());

            double decour = budget * 0.1;

            if (people > 150)
            {
                clothingPrise = clothingPrise - (clothingPrise * 0.1);
            }

            //Защо Уингард няма да плаща на статистите за участието им??? :D
            double cost = decour + (people * clothingPrise);

            if (cost > budget)
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {cost - budget:F02} lv more.");
            }
            else
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {budget - cost:F02} leva left.");
            }
        }
    }
}
