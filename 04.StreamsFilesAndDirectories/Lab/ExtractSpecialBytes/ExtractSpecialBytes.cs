using System.Linq;
using System.Text;

namespace ExtractSpecialBytes
{
    using System;
    using System.IO;
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
            var output = new StringBuilder();
            byte[] binaryFileBytes = Encoding.UTF8.GetBytes(binaryFilePath);
            string[] bytes = File.ReadAllLines(bytesFilePath);

            using (var writer = new StreamWriter(outputPath))
            {
                foreach (var item in binaryFileBytes)
                {
                    if (bytes.Contains(item.ToString()))
                    {
                        output.Append(item.ToString());
                    }
                }
            }

            File.WriteAllText(outputPath, output.ToString());
        }
    }
}
