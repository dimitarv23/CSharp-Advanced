using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;

namespace P03.MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            int n = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string action = cmdArgs[0];
                
                if (action == "1")
                {
                    int num = int.Parse(cmdArgs[1]);

                    stack.Push(num);
                }
                else if (action == "2")
                {
                    if (stack.Count > 0)
                    {
                        stack.Pop();
                    }
                }
                else if (action == "3")
                {
                    if (stack.Count > 0)
                    {
                        Console.WriteLine(stack.Max());
                    }
                }
                else if (action == "4")
                {
                    if (stack.Count > 0)
                    {
                        Console.WriteLine(stack.Min());
                    }
                }
            }

            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
