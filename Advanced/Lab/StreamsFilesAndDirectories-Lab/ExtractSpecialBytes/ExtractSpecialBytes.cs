namespace ExtractSpecialBytes
{
    using System;
    using System.IO;
    using System.Linq;

    public class ExtractSpecialBytes
    {
        static void Main()
        {
            string binaryFilePath = @"..\..\..\Files\example.png";
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            byte[] bytes = File.ReadAllBytes(binaryFilePath);

            using (StreamReader reader = new StreamReader(bytesFilePath))
            {
                byte[] desiredBytes = reader.ReadToEnd().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Select(byte.Parse).ToArray();
                StreamWriter writer = new StreamWriter(outputPath);

                for (int i = 0; i < bytes.Length; i++)
                {
                    for (int x = 0; x < desiredBytes.Length; x++)
                    {
                        if (desiredBytes[x] == bytes[i])
                        {
                            writer.Write(bytes[i]);
                        }
                    }
                }
                writer.Close();
            }
        }
    }
}
