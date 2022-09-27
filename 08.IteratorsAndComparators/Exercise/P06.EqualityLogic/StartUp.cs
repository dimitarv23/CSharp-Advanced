using System;
using System.Collections.Generic;

namespace P06.EqualityLogic
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var people = new HashSet<Person>();
            var sortedPeople = new SortedSet<Person>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] personInfo = Console.ReadLine().Split();

                var person = new Person(personInfo[0], int.Parse(personInfo[1]));
                people.Add(person);
                sortedPeople.Add(person);
            }

            Console.WriteLine(people.Count);
            Console.WriteLine(sortedPeople.Count);
        }
    }
}
