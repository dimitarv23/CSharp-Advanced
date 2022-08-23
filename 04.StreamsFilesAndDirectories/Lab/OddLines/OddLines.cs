namespace OddLines
{
    using System.IO;

    public class OddLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\Files\input.txt";
            string outputFilePath = @"..\..\..\Files\output.txt";

            ExtractOddLines(inputFilePath, outputFilePath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                int index = 0;

                using (StreamReader reader = new StreamReader(inputFilePath))
                {
                    var line = reader.ReadLine();

                    while (line != null)
                    {
                        if (index % 2 == 1)
                        {
                            writer.WriteLine(line);
                        }

                        index++;
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
