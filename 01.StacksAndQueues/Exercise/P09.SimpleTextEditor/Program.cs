using System;
using System.Collections.Generic;
using System.Text;

namespace P09.SimpleTextEditor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<string[]> changes = new Stack<string[]>();
            StringBuilder text = new StringBuilder();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string action = cmdArgs[0];

                if (action == "1")
                {
                    string textToAppend = cmdArgs[1];

                    text.Append(textToAppend);

                    string[] currChange = { "1", textToAppend };
                    changes.Push(currChange);
                }
                else if (action == "2")
                {
                    int count = int.Parse(cmdArgs[1]);
                    string[] currChange = new string[2];
                    currChange[0] = "2";

                    if (text.Length >= count)
                    {
                        currChange[1] = text.ToString().Substring(text.Length - count);
                        text.Remove(text.Length - count, count);
                    }

                    changes.Push(currChange);
                }
                else if (action == "3")
                {
                    int index = int.Parse(cmdArgs[1]);

                    Console.WriteLine(text[index - 1]);
                }
                else if (action == "4")
                {
                    string[] lastChange = changes.Pop();
                    string lastChangeAction = lastChange[0];
                    string lastChangeText = lastChange[1];

                    if (lastChangeAction == "1")
                    {
                        text.Replace(lastChangeText, "");
                    }
                    else if (lastChangeAction == "2")
                    {
                        text.Append(lastChangeText);
                    }
                }
            }
        }
    }
}
