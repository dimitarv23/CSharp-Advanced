﻿using System;

namespace P01.GenericBoxOfString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                var box = new Box<string>(input);

                Console.WriteLine(box);
            }
        }
    }
}
