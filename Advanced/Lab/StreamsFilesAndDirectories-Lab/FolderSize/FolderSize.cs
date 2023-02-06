namespace FolderSize
{
    using System;
    using System.IO;
    public class FolderSize
    {
        static void Main(string[] args)
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(folderPath);
            long fileBytes = GetFolderSize(directoryInfo);

            DirectoryInfo[] dis = directoryInfo.GetDirectories();
            foreach (var dirInfo in dis)
            {
                fileBytes += GetFolderSize(dirInfo);
            }

            File.WriteAllText(outputFilePath, $"{fileBytes / 1024} KB");
        }

        private static long GetFolderSize(DirectoryInfo directoryInfo)
        {
            FileInfo[] files = directoryInfo.GetFiles();
            long fileBytes = 0;
            foreach (var file in files)
            {
                fileBytes += file.Length;
            }

            return fileBytes;
        }
    }
}
