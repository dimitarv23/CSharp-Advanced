using System;
using System.Linq;

namespace P02.Collection
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                ListyIterator<string> listyIterator = null;
                string command = Console.ReadLine();

                while (command != "END")
                {
                    var cmdArgs = command.Split();
                    string action = cmdArgs[0];

                    if (action == "Create")
                    {
                        listyIterator = new ListyIterator<string>(cmdArgs.Skip(1).ToArray());
                    }
                    else if (action == "Move")
                    {
                        Console.WriteLine(listyIterator.Move());
                    }
                    else if (action == "Print")
                    {
                        listyIterator.Print();
                    }
                    else if (action == "HasNext")
                    {
                        Console.WriteLine(listyIterator.HasNext());
                    }
                    else if (action == "PrintAll")
                    {
                        listyIterator.PrintAll();
                    }

                    command = Console.ReadLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
