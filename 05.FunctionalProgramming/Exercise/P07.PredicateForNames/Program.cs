using System;
using System.Linq;

namespace P07.PredicateForNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();

            Func<string, bool> condition = n => n.Length <= length;
            names = names.Where(condition).ToArray();

            if (names.Length > 0)
            {
                foreach (var name in names)
                {
                    Console.WriteLine(name);
                }
            }
        }
    }
}
