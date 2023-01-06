using System;

namespace _10.RE
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int loses = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            int headsetsBroken = 0;
            int miceBroken = 0;
            int keyboardsBroken = 0;
            int displaysBroken = 0;

            for (int i = 1; i <= loses; i++)
            {
                if (i % 6 == 0)
                {
                    miceBroken++;
                    headsetsBroken++;
                    keyboardsBroken++;
                } else if (i % 3 == 0)
                {
                    miceBroken++;
                } else if (i % 2 == 0)
                {
                    headsetsBroken++;
                }

                if (keyboardsBroken % 2 == 0 && i % 6 == 0)
                {
                    displaysBroken++;
                }
            }

            double expenses = (headsetsBroken * headsetPrice) + (miceBroken * mousePrice) + (keyboardsBroken * keyboardPrice) + (displaysBroken * displayPrice);
            Console.WriteLine($"Rage expenses: {expenses:F2} lv.");
        }
    }
}
