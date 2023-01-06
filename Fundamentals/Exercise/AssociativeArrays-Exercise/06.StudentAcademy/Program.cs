using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace _06.StudentAcademy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> goodStudents = new Dictionary<string, List<double>>();

            for (int i = 0; i < rows; i++)
            {
                string student = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!goodStudents.ContainsKey(student))
                {
                    goodStudents[student] = new List<double>();
                }
                goodStudents[student].Add(grade);
            }
            foreach (var student in goodStudents)
            {
                double averageGrade = student.Value.Average();
                if (averageGrade < 4.5)
                {
                    goodStudents.Remove(student.Key);
                }
                else
                {
                    Console.WriteLine($"{student.Key} -> {averageGrade:F2}");
                }
            }
        }
    }
}
