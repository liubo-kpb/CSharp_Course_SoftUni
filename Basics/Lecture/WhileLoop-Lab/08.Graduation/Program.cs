using System;

namespace _08.Graduation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int grade = 1;
            int sacked = 0;
            double averageGrade = 0.0;

            while (grade < 13 && sacked < 2)
            {
                double yearlyGrade = double.Parse(Console.ReadLine());

                if (yearlyGrade >= 4)
                {
                    grade++;
                    
                } else
                {
                    sacked++;
                }
                averageGrade += yearlyGrade;
            }

            if (sacked > 1)
            {
                Console.WriteLine($"{name} has been excluded at {grade} grade");
            } else
            {
                averageGrade /= 12;
                Console.WriteLine($"{name} graduated. Average grade: {averageGrade:F2}");
            }
        }
    }
}
