using System;
using System.Collections.Generic;

namespace P06.Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> names = new Queue<string>();

            string name = Console.ReadLine();
            while (name != "End")
            {
                if (name == "Paid")
                {
                    Console.WriteLine(string.Join(Environment.NewLine, names));
                    names.Clear();
                }
                else
                {
                    names.Enqueue(name);
                }
                
                name = Console.ReadLine();
            }

            Console.WriteLine($"{names.Count} people remaining.");
        }
    }
}
