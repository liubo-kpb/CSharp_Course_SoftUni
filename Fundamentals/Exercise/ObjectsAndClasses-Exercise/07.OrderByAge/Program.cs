using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.OrderByAge
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<User> users = new List<User>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputDetails = input.Split();
                string name = inputDetails[0];
                string id = inputDetails[1];
                int age = int.Parse(inputDetails[2]);
                User user;
                if (users.Any(x => x.ID == id))
                {
                    user = users.Where(x => x.ID == id).FirstOrDefault();
                    user.Name = name;
                    user.Age = age;
                }
                else
                {
                    user = new User(name, id, age);
                    users.Add(user);
                }
            }
            users = users.OrderBy(x => x.Age).ToList();
            foreach (User user in users)
            {
                Console.WriteLine($"{user.Name} with ID: {user.ID} is {user.Age} years old.");
            }
        }
    }

    public class User
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }

        public User(string name, string iD, int age)
        {
            Name = name;
            ID = iD;
            Age = age;
        }
    }
}
