using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace P06.EqualityLogic
{
    public class Person : IComparable<Person>
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public int CompareTo(Person other)
        {
            int result = this.Name.CompareTo(other.Name);

            if (result == 0)
            {
                result = this.Age.CompareTo(other.Age);
            }

            return result;
        }

        public override bool Equals(object obj)
        {
            var other = obj as Person;
            return this.Name == other.Name && this.Age == other.Age;
        }

        public override int GetHashCode()
        {
            var hashCode = this.Name.Length * 10000;
            hashCode = this.Name.Aggregate(hashCode, (current, letter) => current + letter);
            hashCode += this.Age * 10000;

            return hashCode;
        }
    }
}
