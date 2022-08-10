using System;
using System.Linq;
using System.Collections.Generic;

namespace P03.SimpleCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Stack<string> stack = new Stack<string>(input.Reverse());

            while (stack.Count > 1)
            {
                int firstNum = int.Parse(stack.Pop());
                string action = stack.Pop();
                int secondNum = int.Parse(stack.Pop());

                if (action == "+")
                {
                    stack.Push((firstNum + secondNum).ToString());
                }
                else if (action == "-")
                {
                    stack.Push((firstNum - secondNum).ToString());
                }
            }

            Console.WriteLine(stack.Peek());
        }
    }
}
