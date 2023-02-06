namespace LineNumbers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            string[] file = File.ReadAllLines(inputFilePath);
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < file.Length; i++)
            {
                int letters = file[i].Count(char.IsLetter);
                int punctuationMarks = file[i].Count(char.IsPunctuation);
                sb.AppendLine($"Line {i + 1}: {file[i]} ({letters})({punctuationMarks})");
            }

            File.WriteAllText(outputFilePath, sb.ToString());
        }
    }
}
