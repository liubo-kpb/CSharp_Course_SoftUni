using System;
using System.Linq;

namespace _11.ArrayManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            string command = string.Empty;
            ManupulateArray(array, command);
        }

        static void ManupulateArray(int[] array, string command)
        {
            while ((command = Console.ReadLine()) != "end")
            {
                int index = 0;
                
                if (command.Contains("exchange"))
                {
                    index = int.Parse((command.Split())[1]);

                    if (index >= array.Length || index < 0)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }

                    array = ExchangeFromIndex(array, index);
                }
                else if (command.Contains("max") || command.Contains("min"))
                {
                    index = FindRequestedIndex(command, array);
                    if (index == -1)
                    {
                        Console.WriteLine("No matches");
                    }
                    else
                    {
                        Console.WriteLine(index);
                    }
                }
                else if (command.Contains("first") || command.Contains("last"))
                {
                    string[] action = command.Split();
                    string find = action[0];
                    uint findNumbers = uint.Parse(action[1]);
                    string numberType = action[2];

                    if (findNumbers > array.Length)
                    {
                        Console.WriteLine("Invalid count");
                    }
                    else
                    {
                        int[] requestedNumbers = FindRequestedNumbers(find, findNumbers, numberType, array);
                        Console.WriteLine($"[{string.Join(", ", requestedNumbers)}]");
                    }
                    }
                }

            Console.WriteLine($"[{string.Join(", ", array)}]");

        }

        static int[] ExchangeFromIndex(int[] array, int index)
        {
            int[] exchangedArray = new int[array.Length];

            int j = 0;
            for (int i = 0; i < exchangedArray.Length; i++)
            {

                if (index + 1 + i < array.Length)
                {
                    exchangedArray[i] = array[index + 1 + i];
                }
                else
                {
                    exchangedArray[i] = array[j++];
                }
                
                if (index == 0 && i == exchangedArray.Length - 1 && array.Length > 1)
                {
                    exchangedArray[exchangedArray.Length - 1] = array[0];
                    exchangedArray[0] = array[1];
                }

            }

            return exchangedArray;
        }

        static int FindRequestedIndex(string command, int[] array)
        {
            string[] action = command.Split();
            string find = action[0];
            string numberType = action[1];
            int oddOrEven = LookingforOddOrEven(numberType);

            int index = -1;
            switch (find)
            {
                case "max":
                    int maxnumber = int.MinValue;
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (array[i] % 2 == oddOrEven && maxnumber <= array[i])
                        {
                            maxnumber = array[i];
                            index = i;
                        }
                    }
                    break;
                case "min":
                    int minNumber = int.MaxValue;
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (array[i] % 2 == oddOrEven && minNumber >= array[i])
                        {
                            minNumber = array[i];
                            index = i;
                        }
                    }
                    break;
            }

            return index;
        }

        static int[] FindRequestedNumbers(string find, uint findNumbers, string numberType, int[] array)
        {
            int[] requestedNumbers = new int[findNumbers];

            uint foundNumbers = 0;
            int oddOrEven = LookingforOddOrEven(numberType);

            switch (find)
            {
                case "first":
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (array[i] % 2 == oddOrEven)
                        {
                            requestedNumbers[foundNumbers++] = array[i];
                        }
                        if (foundNumbers == findNumbers)
                        {
                            break;
                        }
                    }
                    break;
                case "last":
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (foundNumbers == findNumbers && array[i] % 2 == oddOrEven)
                        {
                            for (int j = 0; j < requestedNumbers.Length - 1; j++)
                            {
                                requestedNumbers[j] = requestedNumbers[j + 1];
                                requestedNumbers[j + 1] = array[i];
                            }
                        } else if (array[i] % 2 == oddOrEven)
                        {
                            requestedNumbers[foundNumbers++] = array[i];
                        }
                    }
                    break;
            }

            int[] finalNumbers = new int[foundNumbers];
            for (int i = 0; i < foundNumbers; i++)
            {
                finalNumbers[i] = requestedNumbers[i];
            }
            if (foundNumbers == 0)
            {
                finalNumbers = new int[0];
            }

            return finalNumbers;
        }

        static int LookingforOddOrEven(string numberType)
        {
            int oddOrEven = -1;
            if (numberType == "odd")
            {
                oddOrEven = 1;
            }
            else
            {
                oddOrEven = 0;
            }

            return oddOrEven;
        }
    }
}
