using System;

namespace _04PasswordGuess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            Math class methods
            Console.WriteLine(Math.Ceiling(4.65));
            Console.WriteLine(Math.Floor(4.65));
            Console.WriteLine(Math.Abs(-65));
            Console.WriteLine(Math.Abs(65));
            */

            string word = Console.ReadLine();         
            const string PASS = "s3cr3t!P@ssw0rd";

            if(word == PASS)
            {
                Console.WriteLine("Welcome");
            }
            else
            {
                Console.WriteLine("Wrong password!");
            }

        }
    }
}
