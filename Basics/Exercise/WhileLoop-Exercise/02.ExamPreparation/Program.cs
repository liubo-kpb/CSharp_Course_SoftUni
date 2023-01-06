using System;

namespace _02.ExamPreparation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int strikes = int.Parse(Console.ReadLine());
            int badGrades = 0;
            int counter = 0;
            double averageGrade = 0;

            string command = Console.ReadLine();
            string lastProblem = "";
            while (command != "Enough")
            {
                counter++;
                lastProblem = command;
                int grade = int.Parse(Console.ReadLine());
                averageGrade += grade;

                if (grade <= 4)
                {
                    badGrades++;
                }
                if (badGrades == strikes)
                {
                    Console.WriteLine($"You need a break, {strikes} poor grades.");
                    return;
                }

                command = Console.ReadLine();
            }
            Console.WriteLine($"Average score: {averageGrade / counter:F2}");
            Console.WriteLine($"Number of problems: {counter}");
            Console.WriteLine($"Last problem: {lastProblem}");
        }
    }
}
