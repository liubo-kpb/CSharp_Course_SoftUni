using System;
using System.Collections.Generic;

namespace _07.CompanyUsers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> msAzure = new Dictionary<string, List<string>>();
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] details = input.Split(" -> ");
                string companyName= details[0];
                string employeeID = details[1];

                if (!msAzure.ContainsKey(companyName))
                {
                    msAzure[companyName] = new List<string>();
                }
                if (!msAzure[companyName].Contains(employeeID))
                {
                    msAzure[companyName].Add(employeeID);
                }
            }

            foreach (var comapny in msAzure)
            {
                Console.WriteLine($"{comapny.Key}");
                foreach (var employeeID in comapny.Value)
                {
                    Console.WriteLine($"-- {employeeID}");
                }
            }
        }
    }
}
