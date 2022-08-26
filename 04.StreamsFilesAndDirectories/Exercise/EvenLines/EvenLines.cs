using System.IO;
using System.Text;

namespace EvenLines
{
    using System;
    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            StringBuilder result = new StringBuilder();

            using (var reader = new StreamReader(inputFilePath))
            {
                string line = reader.ReadLine();
                int counter = 0;

                while (line != null)
                {
                    if (counter % 2 == 1)
                    {
                        line = reader.ReadLine();
                        counter++;
                        continue;
                    }

                    string[] lineWords = line
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    Array.Reverse(lineWords);

                    for (int i = 0; i < lineWords.Length; i++)
                    {
                        lineWords[i] = lineWords[i].Replace('-', '@');
                        lineWords[i] = lineWords[i].Replace(',', '@');
                        lineWords[i] = lineWords[i].Replace('.', '@');
                        lineWords[i] = lineWords[i].Replace('!', '@');
                        lineWords[i] = lineWords[i].Replace('?', '@');

                        result.Append($"{lineWords[i]}");

                        if (i < lineWords.Length - 1)
                        {
                            result.Append(" ");
                        }
                    }


                    counter++;
                    line = reader.ReadLine();

                    if (line != null)
                    {
                        result.Append(Environment.NewLine);
                    }
                }
            }

            return result.ToString();
        }
    }
}
