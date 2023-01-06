using System;

namespace _04.Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int students = int.Parse(Console.ReadLine());

            double counter2 = 0;
            double counter3 = 0;
            double counter4 = 0;
            double counter56 = 0;
            double averageGrade = 0;
            for (int i = 0; i < students; i++)
            {
                double studentGrade = double.Parse(Console.ReadLine());
                averageGrade += studentGrade;

                if (studentGrade < 3)
                {
                    counter2++;
                } else if (studentGrade < 4)
                {
                    counter3++;
                } else if (studentGrade < 5)
                {
                    counter4++;
                } else if (studentGrade >= 5)
                {
                    counter56++;
                }
            }

            Console.WriteLine($"Top students: {counter56 / students * 100:F2}%");
            Console.WriteLine($"Between 4.00 and 4.99: {counter4 / students * 100:F2}%");
            Console.WriteLine($"Between 3.00 and 3.99: {counter3 / students * 100:F2}%");
            Console.WriteLine($"Fail: {counter2 / students * 100:F2}%");
            Console.WriteLine($"Average: {averageGrade / students:F2}");
        }
    }
}
