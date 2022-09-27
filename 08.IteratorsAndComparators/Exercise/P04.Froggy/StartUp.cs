using System;
using System.Linq;

namespace P04.Froggy
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            Lake lake = new Lake(input);
            
            Console.WriteLine(string.Join(", ", lake));
        }
    }
}
