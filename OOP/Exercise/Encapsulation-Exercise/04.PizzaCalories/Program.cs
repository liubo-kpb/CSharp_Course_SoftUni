namespace _04.PizzaCalories
{
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Pizza pizza = null;
                string input = string.Empty;
                while ((input = Console.ReadLine()) != "END")
                {
                    string[] inputArgs = input.Split();
                    switch (inputArgs[0])
                    {
                        case "Pizza":
                            pizza = new Pizza(inputArgs[1]);
                            break;
                        case "Dough":
                            Dough dough = new Dough(inputArgs[1],
                                            inputArgs[2],
                                            double.Parse(inputArgs[3]));
                            pizza.Dough = dough;
                            break;
                        case "Topping":
                            Topping topping = new Topping(inputArgs[1],
                                            double.Parse(inputArgs[2]));
                            pizza.AddTopping(topping);
                            break;

                    }
                }
                Console.WriteLine(pizza);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}
