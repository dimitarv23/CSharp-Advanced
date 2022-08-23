namespace LineNumbers
{
    using System.IO;
    public class LineNumbers
    {
        static void Main()
        {
            string inputPath = @"..\..\..\Files\input.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            RewriteFileWithLineNumbers(inputPath, outputPath);
        }

        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                using (StreamReader reader = new StreamReader(inputFilePath))
                {
                    var line = reader.ReadLine();
                    int index = 1;

                    while (line != null)
                    {
                        writer.WriteLine($"{index}. {line}");
                        index++;

                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
