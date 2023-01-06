using System;
using System.Linq;
using System.Collections.Generic;

namespace _08.AnonymousThreat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "3:1")
            {
                string[] cmdArgs = command.Split();

                switch (cmdArgs[0])
                {
                    case "merge":
                        int startIndex = int.Parse(cmdArgs[1]);
                        int endIndex = int.Parse(cmdArgs[2]);
                        if (startIndex < 0)
                        {
                            startIndex = 0;
                        }
                        if (endIndex >= data.Count)
                        {
                            endIndex = data.Count - 1;
                        }
                        for (int i = startIndex + 1; i <= endIndex; i++)
                        {
                            data[startIndex] += data[i];
                        }
                        for (int i = endIndex; i > startIndex; i--)
                        {
                            data.RemoveAt(i);
                        }
                        break;
                    case "divide":
                        int index = int.Parse(cmdArgs[1]);
                        int partitions = int.Parse(cmdArgs[2]);
                        string dataToDivide = data[index];
                        data.RemoveAt(index);

                        if (dataToDivide.Length % partitions == 0)
                        {
                            int subStringLength = dataToDivide.Length / partitions;
                            for (int i = 0; i < dataToDivide.Length; i += subStringLength)
                            {
                                data.Insert(index++, dataToDivide.Substring(i, subStringLength));
                            }
                        } else
                        {
                            int difference = dataToDivide.Length % partitions;
                            int charsPerSplit = dataToDivide.Length / partitions;
                            int partitionStartIndex = 0;
                            for (int i = 0; i < partitions; i++)
                            {
                                int subStringLength = charsPerSplit;
                                if (i == partitions - 1)
                                {
                                    subStringLength += difference;
                                }
                                data.Insert(index++, dataToDivide.Substring(partitionStartIndex, subStringLength));
                                partitionStartIndex += charsPerSplit;
                            }
                        }
                        break;
                }
            }

            Console.WriteLine(string.Join(" ", data));
        }
    }
}
