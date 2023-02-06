namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            string[] words = new string[0];

            using (StreamReader reader = new StreamReader(wordsFilePath))
            {
                words = reader.ReadToEnd().Split();
            }
            using (StreamReader reader = new StreamReader(textFilePath))
            {
                var wordOccurances = new Dictionary<string, int>();
                StreamWriter writer = new StreamWriter(outputFilePath);
                string[] text = reader.ReadToEnd().Split(new char[] { '.', '?', ' ', '!', '-', ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < words.Length; i++)
                {
                    for (int x = 0; x < text.Length; x++)
                    {
                        if (words[i].ToLower() == text[x].ToLower())
                        {
                            if (!wordOccurances.ContainsKey(words[i]))
                            {
                                wordOccurances[words[i]] = 0;
                            }
                            wordOccurances[words[i]]++;
                        }
                    }
                }
                foreach (var word in wordOccurances.OrderByDescending(x => x.Value))
                {
                    writer.WriteLine($"{word.Key} - {word.Value}");
                }

                writer.Close();
            }
        }
    }
}
