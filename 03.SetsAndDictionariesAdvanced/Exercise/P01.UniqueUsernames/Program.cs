using System;
using System.Collections.Generic;

namespace P01.UniqueUsernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> usernames = new HashSet<string>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string username = Console.ReadLine();

                if (!usernames.Contains(username))
                {
                    usernames.Add(username);
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, usernames));
        }
    }
}
