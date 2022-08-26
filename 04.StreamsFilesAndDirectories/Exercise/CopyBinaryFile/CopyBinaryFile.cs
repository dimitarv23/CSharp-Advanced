using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CopyBinaryFile
{
    using System;
    public class CopyBinaryFile
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string outputFilePath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputFilePath, outputFilePath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            using (FileStream fs = new FileStream(inputFilePath, FileMode.Open))
            {
                byte[] data = new byte[fs.Length];
                fs.Read(data, 0, data.Length);

                using (FileStream copy = new FileStream(outputFilePath, FileMode.OpenOrCreate))
                {
                    copy.Write(data, 0, data.Length);
                }
            }

        }
    }
}
