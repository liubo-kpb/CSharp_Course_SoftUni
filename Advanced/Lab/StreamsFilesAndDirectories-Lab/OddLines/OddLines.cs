namespace OddLines
{
    using System.IO;

    public class OddLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\Files\input.txt";
            string outputFilePath = @"..\..\..\Files\output.txt";

            ExtractOddLines(inputFilePath, outputFilePath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            StreamWriter writer = new StreamWriter(outputFilePath);
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                int line = 0;
                string str = reader.ReadLine();
                while (str != null)
                {
                    if (line % 2 == 1)
                    {
                        writer.WriteLine(str);
                    }
                    str = reader.ReadLine();
                    line++;
                }
                writer.Close();
            }
        }
    }
}
