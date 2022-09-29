using System;
using System.Linq;

namespace P01.RecursiveArraySum
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(SumRecursively(nums, 0));
        }

        static int SumRecursively(int[] arr, int index)
        {
            if (index == arr.Length)
            {
                return 0;
            }

            return arr[index] + SumRecursively(arr, ++index);
        }
    }
}
