using System.IO;
using System.Linq;
using System.Text;

namespace LineNumbers
{
    using System;
    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            StringBuilder result = new StringBuilder();

            using (var reader = new StreamReader(inputFilePath))
            {
                string line = reader.ReadLine();
                int counterLine = 1;

                while (line != null)
                {
                    char[] punctuationMarks = { '.', ',', '-', '!', '?', '\'' };

                    int counterLetters = line.Count(c => char.IsLetter(c));
                    int counterPunctuationMarks = line.Count(c => punctuationMarks.Contains(c));

                    result.AppendLine($"Line {counterLine}: {line} ({counterLetters})({counterPunctuationMarks})");

                    counterLine++;
                    line = reader.ReadLine();
                }
            }

            File.WriteAllText(outputFilePath, result.ToString());
        }
    }
}
