namespace _08.CollectionHierarchy.Core
{
    using System;
    using System.Text;
    using _08.CollectionHierarchy.Models.Interfaces;
    using Microsoft.VisualBasic;
    using Models;
    internal class Engine
    {
        public Engine()
        {
            Run();
        }

        public void Run()
        {
            AddCollection<string> addCollection = new AddCollection<string>();
            AddRemoveCollection<string> addRemoveCollection = new AddRemoveCollection<string>();
            MyList<string> myList = new MyList<string>();

            string[] strings = Console.ReadLine().Split();
            int removeOperations = int.Parse(Console.ReadLine());

            Console.WriteLine(AddElements(strings, addCollection));
            Console.WriteLine(AddElements(strings, addRemoveCollection));
            Console.WriteLine(AddElements(strings, myList));

            Console.WriteLine(RemoveElements(strings, addRemoveCollection, removeOperations));
            Console.WriteLine(RemoveElements(strings, myList, removeOperations));
        }

        public string AddElements(string[] elements, IAddCollection<string> collection)
        {
            StringBuilder str = new StringBuilder();

            for (int i = 0; i < elements.Length; i++)
            {
                str.Append(collection.Add(elements[i]) + " ");
            }

            return str.ToString().TrimEnd();
        }
        public string RemoveElements(string[] elements, IAddRemoveCollection<string> collection, int removeOperations)
        {
            StringBuilder str = new StringBuilder();

            for (int i = 0; i < removeOperations; i++)
            {
                str.Append(collection.Remove() + " ");
            }

            return str.ToString().TrimEnd();
        }
    }
}
