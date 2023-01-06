using System;
using System.Linq;
using System.Text;

namespace _05.MultiplyBigNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string bigNumber = Console.ReadLine();
            int singleNumber = int.Parse(Console.ReadLine());
            StringBuilder result = new StringBuilder();
            int surplus = 0;
            if (bigNumber == "0" || singleNumber == 0)
            {
                Console.WriteLine("0");
                return;
            }
            for (int i = bigNumber.Length - 1; i >= 0; i--)
            {
                int multiplication = (int.Parse(bigNumber[i].ToString()) * singleNumber) + surplus;
                surplus = multiplication / 10;
                result.Append(multiplication % 10);
            }

            if (surplus > 0)
            {
                result.Append(surplus);
            }

            char[] newNumber = result.ToString().Reverse().ToArray();
            Console.WriteLine(string.Join("", newNumber));
        }
    }
}
