using System;
using System.Linq;

namespace P03.CountUppercaseWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> isUppercase = x => Char.IsUpper(x.First());

            string[] uppercaseWords = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Where(isUppercase)
                .ToArray();
            
            Console.WriteLine(string.Join(Environment.NewLine, uppercaseWords));
        }
    }
}
