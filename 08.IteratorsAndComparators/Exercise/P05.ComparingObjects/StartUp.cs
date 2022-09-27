using System;
using System.Collections.Generic;
using System.Linq;

namespace P05.ComparingObjects
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] personInfo = input.Split();

                var person = new Person(personInfo[0], int.Parse(personInfo[1]), personInfo[2]);
                people.Add(person);

                input = Console.ReadLine();
            }

            int n = int.Parse(Console.ReadLine());
            var personToCompare = people[n - 1];

            var equalCount = people.Where(p => p.CompareTo(personToCompare) == 0).Count();

            var unequalCount = people.Where(p => p.CompareTo(personToCompare) != 0).Count();

            if (equalCount > 1)
            {
                Console.WriteLine($"{equalCount} {unequalCount} {people.Count}");
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
    }
}
