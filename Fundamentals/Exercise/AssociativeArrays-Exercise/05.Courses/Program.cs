using System;
using System.Collections.Generic;

namespace _05.Courses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] details = input.Split(" : ");
                string courseName = details[0];
                string student = details[1];

                if (courses.ContainsKey(courseName))
                {
                    courses[courseName].Add(student);
                }
                else
                {
                    courses[courseName] = new List<string>();
                    courses[courseName].Add(student);
                }
            }

            foreach (var course in courses)
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");
                foreach (var student in course.Value)
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }
    }
}
