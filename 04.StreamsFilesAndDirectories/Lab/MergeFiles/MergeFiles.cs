namespace MergeFiles
{
    using System;
    using System.IO;
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            using (var writer = new StreamWriter(outputFilePath))
            {
                using (var reader1 = new StreamReader(firstInputFilePath))
                {
                    using (var reader2 = new StreamReader(secondInputFilePath))
                    {
                        string line1 = reader1.ReadLine();
                        string line2 = reader2.ReadLine();

                        while (line1 != null || line2 != null)
                        {
                            if (line1 == null)
                            {
                                writer.WriteLine(line2);
                            }
                            if (line2 == null)
                            {
                                writer.WriteLine(line1);

                            }

                            if (line1 != null && line2 != null)
                            {
                                writer.WriteLine(line1);
                                writer.WriteLine(line2);
                            }

                            line1 = reader1.ReadLine();
                            line2 = reader2.ReadLine();
                        }
                    }
                }
            }
        }
    }
}
