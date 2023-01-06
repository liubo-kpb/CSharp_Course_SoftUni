using System;

namespace _04.TrainTheTrainers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int juries = int.Parse(Console.ReadLine());
            string presentationName = Console.ReadLine();

            double overallAverageGrade = 0;
            int counter = 0;
            while (presentationName != "Finish")
            {
                counter++;
                double averageGrade = 0;

                for (int i = 0; i < juries; i++)
                {
                    double grade = double.Parse(Console.ReadLine());
                    averageGrade += grade;
                }
                averageGrade /= juries;
                Console.WriteLine($"{presentationName} - {averageGrade:F2}.");

                overallAverageGrade += averageGrade;
                presentationName = Console.ReadLine();
            }
            overallAverageGrade /= counter;
            Console.WriteLine($"Student's final assessment is {overallAverageGrade:F2}.");
        }
    }
}
