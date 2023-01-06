using System;
using System.Text;

namespace _07.StringExplosion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int explosionPower = 0;
            StringBuilder newString= new StringBuilder();
            newString.Append(input.Substring(0, input.IndexOf('>')));
            for (int i = input.IndexOf('>'); i < input.Length; i++)
            {
                if (input[i] == '>' && explosionPower == 0)
                {
                    newString.Append(input[i]);
                    explosionPower += int.Parse(input[++i].ToString());
                    continue;
                } else if (input[i] == '>' && explosionPower > 0)
                {
                    newString.Append(input[i]);
                    explosionPower--;
                    explosionPower += int.Parse(input[++i].ToString());
                } else if (explosionPower > 0)
                {
                    explosionPower--;
                }
                if (explosionPower == 0)
                {
                    newString.Append(input[i]);
                }
            }
            Console.WriteLine(newString);
        }
    }
}
