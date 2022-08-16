﻿using System;
using System.Collections.Generic;

namespace P06.RecordUniqueNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> names = new HashSet<string>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();

                if (!names.Contains(name))
                {
                    names.Add(name);
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, names));
        }
    }
}
