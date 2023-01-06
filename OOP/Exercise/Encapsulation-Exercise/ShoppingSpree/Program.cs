namespace ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static List<Person> users;
        private static List<Product> productList;
        static void Main(string[] args)
        {
            try
            {
                CreateUsers();
                CreateProducts();
                Shopping();

                foreach (var person in users)
                {
                    person.PrintBag();
                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }

        private static void Shopping()
        {
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string personName = cmdArgs[0];
                string productName = cmdArgs[1];

                Person person = users.FirstOrDefault(x => x.Name == personName);
                Product product = productList.FirstOrDefault(x => x.Name == productName);
                if (person.Money >= product.Cost)
                {
                    person.Buy(product);
                }
                else
                {
                    Console.WriteLine($"{person.Name} can't afford {product.Name}");
                }
            }
        }

        private static void CreateProducts()
        {
            productList = new List<Product>();
            string[] products = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < products.Length; i++)
            {
                string[] productDetails = products[i].Split('=');
                Product product = new Product(productDetails[0],
                                              decimal.Parse(productDetails[1]));
                productList.Add(product);
            }
        }

        static void CreateUsers()
        {
            users = new List<Person>();
            string[] people = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < people.Length; i++)
            {
                string[] personDetails = people[i].Split('=');
                Person person = new Person(personDetails[0],
                                           decimal.Parse(personDetails[1]));
                users.Add(person);
            }
        }
    }
}
