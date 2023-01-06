using System;

namespace _04.PasswordValidator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputPassword = Console.ReadLine();

            bool isLong = CheckPasswordLength(inputPassword);
            bool isAlphanumeric = CheckAlphanumericRequirement(inputPassword);
            bool hasTwoDigits = CheckTwoDigitRequirement(inputPassword);

            if (isAlphanumeric && hasTwoDigits && isLong)
            {
                Console.WriteLine("Password is valid");
            }

        }

        static bool CheckPasswordLength(string password)
        {
            bool isValid = true;

            if (password.Length <= 6 || password.Length >= 10)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
                isValid = false;
            }

            return isValid;
        }

        static bool CheckAlphanumericRequirement(string password)
        {
            bool isValid = true;

            foreach (char ch in password)
            {
                if (!Char.IsLetterOrDigit(ch))
                {
                    isValid = false;
                    Console.WriteLine("Password must consist only of letters and digits");
                    break;
                }
            }

            return isValid;
        }

        static bool CheckTwoDigitRequirement(string password)
        {
            bool isValid = true;

            int count = 0;
            foreach (char ch in password)
            {
                if (ch >= 48 && ch <= 57)
                {
                    count++;
                }
                if (count >= 2)
                {
                    break;
                }
            }

            if (count < 2)
            {
                Console.WriteLine("Password must have at least 2 digits");
                isValid = false;
            }

            return isValid;
        }
    }
}
