namespace BorderControl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Model;
    using Model.Interfaces;

    internal class Engine
    {
        private List<IRegister> visitors;
        private List<IBiological> biologicalVisitors;

        public Engine()
        {
            Run();
        }

        private void Run()
        {
            //RunExercises4and5();
            RunExercise6();
        }

        private void RunExercise6()
        {
            FilterOutVisitors();
            RegisterBoughtFood();
        }

        private void RegisterBoughtFood()
        {
            int food = 0;
            string buyerName = string.Empty;
            while ((buyerName = Console.ReadLine()) != "End")
            {
                if (biologicalVisitors.Any(x => x.Name == buyerName))
                {
                    IBuyer buyer = (IBuyer) biologicalVisitors.First(x=> x.Name == buyerName);
                    buyer.BuyFood();
                    food += buyer.FOOD_CAPACITY_PROP;
                }
            }
            Console.WriteLine(food);
        }

        private void FilterOutVisitors()
        {
            biologicalVisitors = new List<IBiological>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                int age = int.Parse(input[1]);

                if (input.Length == 4)
                {
                    string id = input[2];
                    string birthday = input[3];

                    Citizen citizen = new Citizen(name, age, id, birthday);
                    biologicalVisitors.Add(citizen);
                }
                else if (input.Length == 3)
                {
                    string group = input[2];
                    Rebel rebel = new Rebel(name, age, group);
                    biologicalVisitors.Add(rebel);
                }
            }
        }

        private void RunExercises4and5()
        {
            //RegisterVisitors();
            RegisterVisitorsForE5();

            string searchByString = Console.ReadLine();

            //FindAndPrintIntrudors(searchByString);
            FindAndPrintVisitorsWithSameBirthdays(searchByString);
        }

        private void FindAndPrintVisitorsWithSameBirthdays(string birthyear)
        {
            foreach (var biological in biologicalVisitors)
            {
                if (biological.Birthday.EndsWith(birthyear))
                {
                    Console.WriteLine(biological.Birthday);
                }
            }
        }

        private void RegisterVisitorsForE5()
        {
            biologicalVisitors = new List<IBiological>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputDetails = input.Split();
                string visitor = inputDetails[0];

                if (visitor == "Citizen")
                {
                    string name = inputDetails[1];
                    int age = int.Parse(inputDetails[2]);
                    string id = inputDetails[3];
                    string birthday = inputDetails[4];

                    Citizen citizen = new Citizen(name, age, id, birthday);
                    biologicalVisitors.Add(citizen);
                }
                else if (visitor == "Robot")
                {
                    continue;
                }
                else if (visitor == "Pet")
                {
                    string name = inputDetails[1];
                    string birthday = inputDetails[2];

                    Pet pet = new Pet(name, birthday);
                    biologicalVisitors.Add(pet);
                }
            }
        }

        private void FindAndPrintIntrudors(string fakeID)
        {
            foreach (var citizen in visitors)
            {
                if (citizen.Id.EndsWith(fakeID))
                {
                    Console.WriteLine(citizen.Id);
                }
            }
        }

        private void RegisterVisitors()
        {
            visitors = new List<IRegister>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputDetails = input.Split();

                if (inputDetails.Length == 3)
                {
                    string name = inputDetails[0];
                    int age = int.Parse(inputDetails[1]);
                    string id = inputDetails[2];

                    Citizen citizen = new Citizen(name, age, id);
                    visitors.Add(citizen);
                }
                else if (inputDetails.Length == 2)
                {
                    string model = inputDetails[0];
                    string id = inputDetails[1];

                    Robot robot = new Robot(model, id);
                    visitors.Add(robot);
                }
            }
        }
    }
}
