using System;
using System.Collections.Generic;
using System.Linq;

namespace P2.StackSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputNums = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> stack = new Stack<int>(inputNums);
            
            string command = Console.ReadLine().ToLower();
            while (command != "end")
            {
                string[] cmdArgs = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string action = cmdArgs[0];

                if (action == "add")
                {
                    int firstNum = int.Parse(cmdArgs[1]);
                    int secondNum = int.Parse(cmdArgs[2]);

                    stack.Push(firstNum);
                    stack.Push(secondNum);
                }
                else if (action == "remove")
                {
                    int num = int.Parse(cmdArgs[1]);

                    if (stack.Count >= num)
                    {
                        for (int i = 0; i < num; i++)
                        {
                            stack.Pop();
                        }
                    }
                }
                
                command = Console.ReadLine().ToLower();
            }

            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
