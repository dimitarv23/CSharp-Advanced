using System.Text;

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
            byte[] fileBytes = Encoding.UTF8.GetBytes(sourceFilePath);

            using (var writer1 = new StreamWriter(partOneFilePath))
            {
                using (var writer2 = new StreamWriter(partTwoFilePath))
                {
                    for (int i = 0; i < fileBytes.Length; i++)
                    {
                        if (i <= fileBytes.Length / 2 + 1)
                        {
                            writer1.Write(fileBytes[i]);
                        }
                        else
                        {
                            writer2.Write(fileBytes[i]);
                        }
                    }
                }
            }
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            byte[] partOneBytes = Encoding.UTF8.GetBytes(partOneFilePath);
            byte[] partTwoBytes = Encoding.UTF8.GetBytes(partTwoFilePath);

            using (var writer = new StreamWriter(joinedFilePath))
            {
                foreach (var item in partOneBytes)
                {
                    writer.Write(item);
                }

                foreach (var item in partTwoBytes)
                {
                    writer.Write(item);
                }
            }
        }
    }
}