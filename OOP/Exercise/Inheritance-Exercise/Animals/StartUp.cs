using System;

namespace Animals
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string command = string.Empty;
            
            while ((command = Console.ReadLine()) != "Beast!")
            {
                string animal = command;
                string[] animalDetails = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = animalDetails[0];
                int age = int.Parse(animalDetails[1]);
                string gender = string.Empty;

                try
                {
                    if (age < 0)
                    {
                        throw new ArgumentException("Invalid input!");
                    }
                    if (animalDetails.Length > 2)
                    {
                        gender = animalDetails[2];
                    }

                    switch (animal)
                    {
                        case "Dog":
                            Dog dog = new Dog(name, age, gender);
                            Console.WriteLine(dog.ToString());
                            break;
                        case "Cat":
                            Cat cat = new Cat(name, age, gender);
                            Console.WriteLine(cat.ToString());
                            break;
                        case "Frog":
                            Frog frog = new Frog(name, age, gender);
                            Console.WriteLine(frog.ToString());
                            break;
                        case "Kitten":
                            Kitten kittens = new Kitten(name, age);
                            Console.WriteLine(kittens.ToString());
                            break;
                        case "Tomcat":
                            Tomcat tomcat = new Tomcat(name, age);
                            Console.WriteLine(tomcat.ToString());
                            break;
                        default:
                            throw new ArgumentException("Invalid input!");
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
