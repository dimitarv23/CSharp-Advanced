using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;

namespace P01.BasicStackOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] stackInfo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int elementsToPop = stackInfo[1];
            int searchedElement = stackInfo[2];

            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                stack.Push(numbers[i]);
            }

            for (int i = 0; i < elementsToPop; i++)
            {
                stack.Pop();
            }

            if (stack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                if (stack.Contains(searchedElement))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(stack.Min());
                }
            }
        }
    }
}
