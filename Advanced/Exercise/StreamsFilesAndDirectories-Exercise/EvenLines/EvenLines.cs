namespace EvenLines
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            StringBuilder sb = new StringBuilder();
            char[] symbols = { '-', ',', '.', '!', '?' };

            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                int row = 0;
                string line = reader.ReadLine();
                while (line != null)
                {
                    if (row % 2 == 0)
                    {
                        sb.AppendLine(string.Join(" ", line.Split().Reverse().ToArray()));
                        for (int i = 0; i < symbols.Length; i++)
                        {
                            sb = sb.Replace(symbols[i], '@');
                        }
                    }
                    row++;
                    line = reader.ReadLine();
                }
            }

            return sb.ToString();
        }
    }
}
