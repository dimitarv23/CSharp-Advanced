using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> people;

        public Family()
        {
            this.People = new List<Person>();
        }

        public List<Person> People
        {
            get { return people; }
            set { people = value; }
        }

        public void AddMembers(Person member)
        {
            People.Add(member);
        }

        public Person GetOldest()
        {
            int maxAge = -1;
            string oldestName = string.Empty;

            foreach (var person in people)
            {
                if (person.Age > maxAge)
                {
                    maxAge = person.Age;
                    oldestName = person.Name;
                }
            }

            return people.First(p => p.Name == oldestName && p.Age == maxAge);
        }
    }
}
