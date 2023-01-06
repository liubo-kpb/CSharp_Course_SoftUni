using System;
using System.Text;

namespace _04.CaesarCipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder encryptedText = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                int charEncryption = input[i] + 3;
                encryptedText.Append((char) charEncryption);
            }
            Console.WriteLine(encryptedText);
        }
    }
}
