﻿namespace CopyDirectory
{
    using System;
    using System.IO;

    public class CopyDirectory
    {
        static void Main()
        {
            string inputPath = @$"{Console.ReadLine()}";
            string outputPath = @$"{Console.ReadLine()}";

            CopyAllFiles(inputPath, outputPath);
        }

        public static void CopyAllFiles(string inputPath, string outputPath)
        {
            if (Directory.Exists(outputPath))
            {
                Directory.Delete(outputPath, true);
            }

            string[] files = Directory.GetFiles(inputPath);
            foreach (var file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                File.Copy(fileInfo.FullName, outputPath);
            }
        }
    }
}
