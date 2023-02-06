namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            StringBuilder sb = new StringBuilder();
            Dictionary<string, Dictionary<string, long>> documentation = new Dictionary<string, Dictionary<string, long>>();
            string[] files = Directory.GetFiles(inputFolderPath);

            foreach (var file in files)
            {
                FileInfo fi = new FileInfo(file);
                string fileExtension = fi.Extension;
                string fileName = fi.Name;
                long fileSize = fi.Length;

                if (!documentation.ContainsKey(fileExtension))
                {
                    documentation[fileExtension] = new Dictionary<string, long>();
                }
                documentation[fileExtension].Add(fileName, fileSize);
            }

            foreach (var extension in documentation.OrderByDescending(f => f.Value.Count).ThenBy(f => f.Key))
            {
                sb.AppendLine(extension.Key);
                foreach (var file in extension.Value.OrderBy(s => s.Value))
                {
                    sb.AppendLine($"--{file.Key} - {file.Value / 1024}kb");
                }
            }

            return sb.ToString();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + reportFileName;
            File.WriteAllText(desktop, textContent);
        }
    }
}
