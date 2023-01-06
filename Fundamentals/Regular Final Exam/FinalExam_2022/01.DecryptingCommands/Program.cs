using System;
using System.Linq;
using System.Text;

namespace _01.DecryptingCommands
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder str = new StringBuilder(Console.ReadLine());
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Finish")
            {
                string[] cmdArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (cmdArgs.Length == 0)
                {
                    continue;
                }
                string action = cmdArgs[0];

                int startIndex = 0;
                int endIndex = 0;
                int subStringLength = 0;
                switch (action)
                {
                    case "Replace":
                        string currentChar = cmdArgs[1];
                        string newChar = cmdArgs[2];
                        if (str.ToString().Contains(currentChar))
                        {
                            str.Replace(currentChar, newChar);
                            Console.WriteLine(str);
                        }
                        break;
                    case "Cut":
                        startIndex = int.Parse(cmdArgs[1]);
                        endIndex = int.Parse(cmdArgs[2]);

                        if (startIndex > endIndex || startIndex < 0 || endIndex >= str.Length)
                        {
                            Console.WriteLine("Invalid indices!");
                            break;
                        }

                        subStringLength = endIndex - startIndex + 1;
                        str.Remove(startIndex, subStringLength);
                        Console.WriteLine(str);
                        break;
                    case "Make":
                        string caseChangeRequest = cmdArgs[1];
                        if (caseChangeRequest == "Upper")
                        {
                            str = new StringBuilder(str.ToString().ToUpper());
                        }
                        else if (caseChangeRequest == "Lower")
                        {
                            str = new StringBuilder(str.ToString().ToLower());
                        }
                        Console.WriteLine(str);
                        break;
                    case "Check":
                        string messagePiece = cmdArgs[1];
                        if (str.ToString().Contains(messagePiece))
                        {
                            Console.WriteLine($"Message contains {messagePiece}");
                        }
                        else
                        {
                            Console.WriteLine($"Message doesn't contain {messagePiece}");
                        }
                        break;
                    case "Sum":
                        startIndex = int.Parse(cmdArgs[1]);
                        endIndex = int.Parse(cmdArgs[2]);

                        if (startIndex > endIndex || startIndex < 0 || endIndex >= str.Length)
                        {
                            Console.WriteLine("Invalid indices!");
                            break;
                        }

                        int sum = 0;
                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            sum += str[i];
                        }
                        Console.WriteLine(sum);
                        break;
                }
            }
        }
    }
}
