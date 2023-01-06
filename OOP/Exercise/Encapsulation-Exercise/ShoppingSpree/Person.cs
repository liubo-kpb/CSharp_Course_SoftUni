namespace ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks.Dataflow;

    public class Person
    {
        private string name;
        private decimal money;
        private List<string> bag;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;

        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Name cannot be empty");

                name = value;
            }
        }

        public decimal Money
        {
            get { return money; }
            private set
            {
                if (value < 0) throw new ArgumentException("Money cannot be negative");

                money = value;
            }
        }

        public void Buy(Product product)
        {
            if (bag == null)
            {
                bag = new List<string>();
            }

            bag.Add(product.Name);
            money -= product.Cost;
            Console.WriteLine($"{name} bought {product.Name}");
        }

        internal void PrintBag()
        {
            if (bag != null)
            {
                Console.WriteLine($"{name} - {string.Join(", ", bag)}");
            } else
            {
                Console.WriteLine($"{name} - Nothing bought");
            }
        }
    }
}
