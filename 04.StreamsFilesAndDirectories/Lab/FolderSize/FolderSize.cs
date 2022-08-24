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
            decimal folderSize = GetDirSize(folderPath);

            File.WriteAllText(outputFilePath, $"{folderSize / 1000} KB");
        }

        static decimal GetDirSize(string folderPath)
        {
            decimal folderSize = 0;

            foreach (var file in Directory.GetFiles(folderPath))
            {
                FileInfo fileInfo = new FileInfo(file);
                folderSize += fileInfo.Length;
            }

            foreach (var dir in Directory.GetDirectories(folderPath))
            {
                folderSize += GetDirSize(dir);
            }

            return folderSize;
        }
    }
}
