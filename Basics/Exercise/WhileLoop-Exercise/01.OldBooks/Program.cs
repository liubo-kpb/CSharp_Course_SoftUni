using System;

namespace _01.OldBooks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string favouriteBook = Console.ReadLine();
            string book = Console.ReadLine();
            int counter = 0;

            while (favouriteBook != book && book != "No More Books")
            {
                counter++;
                book = Console.ReadLine();
            }

            if (book == "No More Books")
            {
                Console.WriteLine($"The book you search is not here!");
                Console.WriteLine($"You checked {counter} books.");
            } else
            {
                Console.WriteLine($"You checked {counter} books and found it.");
            }
        }
    }
}
