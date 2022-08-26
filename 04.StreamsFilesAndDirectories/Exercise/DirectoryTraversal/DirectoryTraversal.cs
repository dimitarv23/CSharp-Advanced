using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DirectoryTraversal
{
    using System;
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
            var result = new StringBuilder();

            var dir = new DirectoryInfo(inputFolderPath);
            var files = new Dictionary<string, List<string>>();

            foreach (var file in dir.GetFiles()
                         .OrderBy(file => file.Extension)
                         .ThenBy(file => file.Length))
            {
                if (!files.ContainsKey(file.Extension))
                {
                    files.Add(file.Extension, new List<string>());
                }

                files[file.Extension].Add($"--{file.Name} - {(decimal)file.Length / 1000}kb");
            }

            foreach (var file in files)
            {
                result.AppendLine(file.Key);

                foreach (var info in file.Value)
                {
                    result.AppendLine(info);
                }
            }

            return result.ToString();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            using (var fs = new FileStream(desktopPath, FileMode.Create))
            {
                fs.Write(Encoding.UTF8.GetBytes(textContent));
            }
        }
    }
}
