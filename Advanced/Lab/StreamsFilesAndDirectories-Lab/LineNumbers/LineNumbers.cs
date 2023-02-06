namespace LineNumbers
{
    using System.IO;
    public class LineNumbers
    {
        static void Main()
        {
            string inputPath = @"..\..\..\Files\input.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            RewriteFileWithLineNumbers(inputPath, outputPath);
        }

        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                StreamWriter writer = new StreamWriter(outputFilePath);
                int line = 1;
                string str = reader.ReadLine();
                while (str != null)
                {
                    writer.WriteLine($"{line++}. {str}");
                    str = reader.ReadLine();
                }
                writer.Close();
            }
        }
    }
}
