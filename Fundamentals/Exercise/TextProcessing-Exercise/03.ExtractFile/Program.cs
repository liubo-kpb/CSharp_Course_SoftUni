using System;

namespace _03.ExtractFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] pathArray = Console.ReadLine().Split('\\');
            string[] file = pathArray[^1].Split('.');
            string fileName = file[0];
            string fileType = file[1];
            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {fileType}");
        }
    }
}
