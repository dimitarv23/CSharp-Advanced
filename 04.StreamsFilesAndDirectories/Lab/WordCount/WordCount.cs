using System.Text;

namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            var words = new StringBuilder();

            using (var reader = new StreamReader(wordsFilePath))
            {
                string currLine = reader.ReadLine();

                while (currLine != null)
                {
                    words.Append($"{currLine} ");
                    currLine = reader.ReadLine();
                }
            }

            string[] wordsArray = words.ToString().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var occurrencies = new Dictionary<string, int>();

            using (var writer = new StreamWriter(outputFilePath))
            {
                using (var reader = new StreamReader(textFilePath))
                {
                    string line = reader.ReadLine();

                    while (line != null)
                    {
                        string[] lineWords = line.ToLower().Split(
                            new [] { ' ', '-', '.', ',', '!', '?', ':' }, StringSplitOptions.RemoveEmptyEntries);

                        foreach (string word in lineWords)
                        {
                            if (wordsArray.Contains(word))
                            {
                                if (!occurrencies.ContainsKey(word))
                                {
                                    occurrencies.Add(word, 0);
                                }

                                occurrencies[word]++;
                            }
                        }

                        line = reader.ReadLine();
                    }
                }

                foreach (var occurrence in occurrencies
                             .OrderByDescending(o => o.Value))
                {
                    writer.WriteLine($"{occurrence.Key} - {occurrence.Value}");
                }
            }
        }
    }
}
