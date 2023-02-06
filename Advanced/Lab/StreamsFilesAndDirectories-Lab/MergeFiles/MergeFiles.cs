namespace MergeFiles
{
    using System;
    using System.IO;
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            using (StreamReader reader1 = new StreamReader(firstInputFilePath))
            {
                StreamReader reader2 = new StreamReader(secondInputFilePath);
                StreamWriter writer = new StreamWriter(outputFilePath);

                string file1 = reader1.ReadLine();
                string file2 = reader2.ReadLine();
                while (file1 != null && file2 != null)
                {
                    if (file1 != null)
                    {
                        writer.WriteLine(file1);
                    }
                    if (file2 != null)
                    {
                        writer.WriteLine(file2);
                    }

                    file1 = reader1.ReadLine();
                    file2 = reader2.ReadLine();
                }

                writer.Close();
                reader2.Close();
            }
        }
    }
}
