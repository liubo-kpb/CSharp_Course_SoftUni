namespace MilitaryElite.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Models.Interfaces;
    using Models;
    internal class Engine
    {

        public Engine() { Run(); }

        private void Run()
        {
            List<ISoldier> soldiers = new List<ISoldier>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                try
                {
                    string[] information = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string soldier = information[0];
                    string id = information[1];
                    string firstName = information[2];
                    string lastName = information[3];

                    if (soldier == "Private")
                    {
                        decimal salary = decimal.Parse(information[4]);
                        Private privateSoldier = new Private(firstName, lastName, id, salary);
                        soldiers.Add(privateSoldier);
                    }
                    else if (soldier == "LieutenantGeneral")
                    {
                        decimal salary = decimal.Parse(information[4]);
                        var lieutenant = new LieutenantGeneral(firstName, lastName, id, salary, GetPrivates(information.Skip(4).ToArray(), soldiers));
                        soldiers.Add(lieutenant);
                    }
                    else if (soldier == "Engineer")
                    {
                        decimal salary = decimal.Parse(information[4]);
                        string corps = information[5];
                        Engineer engineer = new Engineer(firstName, lastName, id, salary, corps, GetRepairs(information.Skip(6).ToArray()));
                        soldiers.Add(engineer);
                    }
                    else if (soldier == "Commando")
                    {
                        decimal salary = decimal.Parse(information[4]);
                        string corps = information[5];
                        Commando commando = new Commando(firstName, lastName, id, salary, corps, GetMissions(information.Skip(6).ToArray()));
                        soldiers.Add(commando);
                    }
                    else if (soldier == "Spy")
                    {
                        int codeNumber = int.Parse(information[4]);
                        var spy = new Spy(firstName, lastName, id, codeNumber);
                        soldiers.Add(spy);
                    }
                }
                catch (ArgumentException) { }
            }
            Console.WriteLine(string.Join(Environment.NewLine, soldiers));
        }

        private Mission[] GetMissions(string[] strings)
        {
            Mission[] missions = new Mission[strings.Length / 2];
            int n = 0;
            for (int i = 0; i < missions.Length; i++)
            {
                try
                {
                    if (n <= strings.Length - 1)
                    {
                        missions[i] = new Mission(strings[n++], strings[n++]);
                    }
                }
                catch (ArgumentException)
                {
                    --i;
                }
            }

            return missions;
        }

        private Repair[] GetRepairs(string[] strings)
        {
            Repair[] repairs = new Repair[strings.Length / 2];

            int n = 0;
            for (int i = 0; i < repairs.Length; i++)
            {
                repairs[i] = new Repair(strings[n++], int.Parse(strings[n++]));
            }

            return repairs;
        }

        private List<ISoldier> GetPrivates(string[] information, List<ISoldier> privates)
        {
            List<ISoldier> members = new List<ISoldier>();
            for (int i = 0; i < information.Length; i++)
            {
                if (privates.Any(x => x.Id == information[i]))
                {
                    members.Add(privates.FirstOrDefault(x => x.Id == information[i]));
                }
            }

            return members;
        }
    }
}
