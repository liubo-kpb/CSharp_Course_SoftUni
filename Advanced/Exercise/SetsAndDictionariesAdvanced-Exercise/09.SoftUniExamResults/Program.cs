using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.SoftUniExamResults
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> studentSubmissions = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, int> courseSubmissions = new Dictionary<string, int>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "exam finished")
            {
                string[] submissionDetails = input.Split("-", StringSplitOptions.RemoveEmptyEntries);
                string username = submissionDetails[0];
                string language = submissionDetails[1];

                if (language == "banned")
                {
                    studentSubmissions.Remove(username);
                    continue;
                }

                int submissionPoints = int.Parse(submissionDetails[2]);

                if (!studentSubmissions.ContainsKey(username))
                {
                    studentSubmissions[username] = new Dictionary<string, int>();
                }
                if (!studentSubmissions[username].ContainsKey(language))
                {
                    studentSubmissions[username][language] = 0;
                }
                if (submissionPoints > studentSubmissions[username][language])
                {
                    studentSubmissions[username][language] = submissionPoints;
                }
                if (!courseSubmissions.ContainsKey(language))
                {
                    courseSubmissions[language] = 0;
                }
                courseSubmissions[language]++;
            }

            Console.WriteLine("Results:");
            foreach (var studentSubmission in studentSubmissions.OrderByDescending(x => x.Value.Values.First()).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{studentSubmission.Key} | {studentSubmission.Value.Values.First()}");
            }
            Console.WriteLine("Submissions:");
            foreach (var courseSubmission in courseSubmissions.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{courseSubmission.Key} - {courseSubmission.Value}");
            }
        }
    }
}