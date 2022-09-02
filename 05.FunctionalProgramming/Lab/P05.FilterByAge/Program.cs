using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace P05.FilterByAge
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] pair = Console.ReadLine()
                    .Split(", ");

                Person person = new Person()
                {
                    Name = pair[0],
                    Age = int.Parse(pair[1])
                };

                people.Add(person);
            }

            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            //By default => condition is "older"
            Func<Person, bool> filter = x => true;
            Func<Person, string> outputFormat = x => $"{x.Name} {x.Age}";

            if (condition == "younger")
            {
                filter = x => x.Age < age;
            }
            else if (condition == "older")
            {
                filter = x => x.Age >= age;
            }

            var filteredPeople = people.Where(filter);

            if (format == "name age")
            {
                outputFormat = x => $"{x.Name} - {x.Age}";
            }
            else if (format == "age")
            {
                outputFormat = x => $"{x.Age}";
            }
            else if (format == "name")
            {
                outputFormat = x => $"{x.Name}";
            }

            var outputInformation = filteredPeople.Select(outputFormat);
            foreach (var p in outputInformation)
            {
                Console.WriteLine(p);
            }
        }
    }
}