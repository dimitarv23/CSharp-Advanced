using System;
using System.Collections.Generic;
using System.Linq;

namespace P05.MergeSort
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            MergeSort.Sort(nums);

            Console.WriteLine(string.Join(" ", nums));
        }
    }

    public class MergeSort
    {
        public static void Sort(List<int> list)
        {
            for (int k = 0; k < list.Count - 1; k++)
            {
                for (int i = 0; i < list.Count - 1; i++)
                {
                    if (list[i].CompareTo(list[i + 1]) > 0)
                    {
                        var temp = list[i];
                        list[i] = list[i + 1];
                        list[i + 1] = temp;
                    }
                }

                if (IsSorted(list))
                {
                    break;
                }
            }
        }

        static bool IsSorted(List<int> list)
        {
            bool result = true;

            for (int i = 0; i < list.Count - 1; i++)
            {
                if (list[i] > list[i + 1])
                {
                    result = false;
                }
            }

            return result;
        }
    }
}