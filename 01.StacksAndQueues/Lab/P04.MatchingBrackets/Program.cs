using System;
using System.Collections.Generic;
using System.Linq;

namespace P04.MatchingBrackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> indicesOfSubexpressions = new Stack<int>();
            List<string> bracketExpressions = new List<string>();
            string expression = Console.ReadLine();

            for (int i = 0; i < expression.Length; i++)
            {
                char c = expression[i];

                if (c == '(')
                {
                    indicesOfSubexpressions.Push(i);
                }
                else if (c == ')')
                {
                    int startIndex = indicesOfSubexpressions.Pop();

                    bracketExpressions.Add(expression.Substring(startIndex, i - startIndex + 1));
                }
            }

            foreach (var e in bracketExpressions)
            {
                Console.WriteLine(e);
            }
        }
    }
}
