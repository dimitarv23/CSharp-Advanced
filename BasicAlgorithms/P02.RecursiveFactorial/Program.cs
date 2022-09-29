using System;

namespace P02.RecursiveFactorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(GetFactorialRecursively(n));
        }

        static long GetFactorialRecursively(int n)
        {
            if (n == 1)
            {
                return 1;
            }

            return n * GetFactorialRecursively(n - 1);
        }
    }
}
