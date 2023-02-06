namespace SplitMergeBinaryFile
{
    using System;
    using System.IO;
    using System.Linq;

    public class SplitMergeBinaryFile
    {
        static void Main()
        {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            byte[] bytes = File.ReadAllBytes(sourceFilePath);

            using (StreamWriter writer1 = new StreamWriter(partOneFilePath))
            {
                StreamWriter writer2 = new StreamWriter(partTwoFilePath);

                for (int i = 0; i < bytes.Length; i++)
                {
                    writer1.Write(bytes[i]);
                    if (i < bytes.Length - 1)
                    {
                        writer2.Write(bytes[++i]);
                    }
                }
                writer2.Close();
            }
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            byte[] bytes1 = File.ReadAllBytes(partOneFilePath);
            byte[] bytes2 = File.ReadAllBytes(partTwoFilePath);

            using (StreamWriter writer = new StreamWriter(joinedFilePath))
            {
                for (int i = 0; i < bytes1.Length; i++)
                {
                    writer.Write(bytes1[i]);
                    if (i < bytes2.Length - 1)
                    {
                        writer.Write(bytes2[++i]);
                    }
                }
            }
        }
    }
}