using System;

namespace _06.CinemaTickets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            double studentTicket = 0;
            double standardTicket = 0;
            double kidTicket = 0;
            double overallTickets = 0;

            while (command != "Finish")
            {
                int spots = int.Parse(Console.ReadLine());
                double ticketsForFilm = 0;
                string ticketType = Console.ReadLine();
                while (ticketType != "End")
                {
                    switch (ticketType)
                    {
                        case "student":
                            studentTicket++;
                            break;
                        case "standard":
                            standardTicket++;
                            break;
                        case "kid":
                            kidTicket++;
                            break;
                    }
                    ticketsForFilm++;
                    overallTickets++;
                    if (ticketsForFilm >= spots)
                    {
                        break;
                    }
                    ticketType = Console.ReadLine();
                }
                double percentFull = ticketsForFilm / spots * 100;
                Console.WriteLine($"{command} - {percentFull:F2}% full.");

                command = Console.ReadLine();
            }

            Console.WriteLine($"Total tickets: {overallTickets}");
            Console.WriteLine($"{studentTicket / overallTickets * 100:F2}% student tickets.");
            Console.WriteLine($"{standardTicket / overallTickets * 100:F2}% standard tickets.");
            Console.WriteLine($"{kidTicket / overallTickets * 100:F2}% kids tickets.");

        }
    }
}
