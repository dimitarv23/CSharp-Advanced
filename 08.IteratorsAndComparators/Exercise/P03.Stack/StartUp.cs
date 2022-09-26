using System;
using System.Linq;

namespace P03.Stack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var stack = new Stack<string>();
            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] cmdArgs = command.Split();
                string action = cmdArgs[0];

                try
                {
                    if (action == "Push")
                    {
                        var values = command.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                            .Skip(1).ToArray();

                        stack.Push(values);
                    }
                    else if (action == "Pop")
                    {
                        stack.Pop();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                command = Console.ReadLine();
            }

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
