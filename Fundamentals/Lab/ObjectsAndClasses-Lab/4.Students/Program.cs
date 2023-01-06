using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = string.Empty;
            List<Student> list = new List<Student>();

            while ((command = Console.ReadLine()) != "end")
            {
                string[] cmdArgs = command.Split();
                string fName = cmdArgs[0];
                string lName = cmdArgs[1];
                int age = int.Parse(cmdArgs[2]);
                string homeTown = cmdArgs[3];
                Student student = new Student(fName, lName, age, homeTown);
                foreach (var item in list.Where(x => x.FirstName == fName && x.LastName == lName))
                {
                    item.Age = age;
                    item.HomeTown = homeTown;
                }
                if (!list.Any(x => x.FirstName == fName && x.LastName == lName))
                {
                    list.Add(student);
                }
            }
            command = Console.ReadLine();

            foreach(var student in list.Where(x => x.HomeTown == command))
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
            }
        }
    }

    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string HomeTown { get; set; }

        public Student(string firstName, string lastName, int age, string homeTown)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            HomeTown = homeTown;
        }
    }
}
