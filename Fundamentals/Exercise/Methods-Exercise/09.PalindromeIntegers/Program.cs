using System;

namespace _09.PalindromeIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                Console.WriteLine(isPalindrome(command));
            }
        }

        static bool isPalindrome (string str)
        {
            bool isPalindrome = true;

            for(int i = 0; i < str.Length / 2 ; i++)
            {
                if (str[i] != str[str.Length - i - 1])
                {
                    isPalindrome = false;
                    break;
                }
            }

            return isPalindrome;
        }
    }
}
