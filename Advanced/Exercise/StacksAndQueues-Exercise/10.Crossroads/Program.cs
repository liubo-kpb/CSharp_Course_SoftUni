using System;
using System.Collections.Generic;

namespace _10.Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int greenLightTime = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();

            int passedCars = 0;
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                if (command == "green")
                {
                    int timeLeft = greenLightTime;
                    string currentCar = string.Empty;

                    while (timeLeft > 0 && cars.Count > 0)
                    {
                        currentCar = cars.Dequeue();
                        timeLeft -= currentCar.Length;
                        if (timeLeft >= 0)
                        {
                            passedCars++;
                        }
                    }

                    int carRemainder = 0;
                    if (cars.Count > 0 || timeLeft <= 0)
                    {
                        carRemainder = Math.Abs(timeLeft);
                    }

                    if (carRemainder == 0)
                    {
                        continue;
                    }
                    else if (carRemainder <= freeWindow)
                    {
                        passedCars++;
                    }
                    else
                    {
                        int hitCharacter = currentCar.Length - (Math.Abs(freeWindow - carRemainder));
                        Console.WriteLine($"A crash happened!" +
                            $"{Environment.NewLine}{currentCar} was hit at {currentCar[hitCharacter]}.");
                        return;
                    }
                }
                else
                {
                    cars.Enqueue(command);
                }
            }
            Console.WriteLine("Everyone is safe." +
                $"{Environment.NewLine + passedCars} total cars passed the crossroads.");
        }
    }
}
