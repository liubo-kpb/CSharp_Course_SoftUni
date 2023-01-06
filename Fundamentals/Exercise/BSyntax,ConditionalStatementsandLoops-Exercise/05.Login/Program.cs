using System;

namespace _05.Login
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = string.Empty;

            for (int i = username.Length - 1; i >= 0; i--)
            {
                char letter = username[i];
                password += letter;
            }

            int loginAttempt = 0;
            while (Console.ReadLine() != password)
            {
                
                loginAttempt++;

                if (loginAttempt >= 4)
                {
                    Console.WriteLine($"User {username} blocked!");
                    return;
                }
                Console.WriteLine("Incorrect password. Try again.");
            }

            Console.WriteLine($"User {username} logged in.");
        }
    }
}
