using System;
using System.Collections.Generic;

namespace P08.BalancedParenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();
            Stack<char> stack = new Stack<char>();

            bool isCorrect = true;

            foreach (char bracket in expression)
            {
                if (bracket == '(' || bracket == '[' || bracket == '{')
                {
                    stack.Push(bracket);
                }
                else if (bracket == ')')
                {
                    if (stack.Count == 0)
                    {
                        isCorrect = false;
                        break;
                    }

                    if (stack.Peek() == '(')
                    {
                        stack.Pop();
                    }
                }
                else if (bracket == ']')
                {
                    if (stack.Count == 0)
                    {
                        isCorrect = false;
                        break;
                    }

                    if (stack.Peek() == '[')
                    {
                        stack.Pop();
                    }
                }
                else if (bracket == '}')
                {
                    if (stack.Count == 0)
                    {
                        isCorrect = false;
                        break;
                    }

                    if (stack.Peek() == '{')
                    {
                        stack.Pop();
                    }
                }
            }

            if (stack.Count > 0 || isCorrect == false)
            {
                Console.WriteLine("NO");
            }
            else
            {
                Console.WriteLine("YES");
            }
        }
    }
}
