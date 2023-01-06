using System;

namespace _11.Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double totalPrice = 0;
            for (int i = 1; i <= n; i++)
            {
                double capsulePrice = double.Parse(Console.ReadLine());
                int days = int.Parse(Console.ReadLine());
                int capsuleCount = int.Parse(Console.ReadLine());

                double orderPrice = days * capsuleCount * capsulePrice;
                Console.WriteLine($"The price for the coffee is: ${orderPrice:F2}");
                totalPrice += orderPrice;
            }
            Console.WriteLine($"Total: ${totalPrice:F2}");
        }
    }
}
