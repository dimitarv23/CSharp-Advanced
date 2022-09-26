using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    public class Book : IComparable<Book>
    {
        private string title;
        private int year;
        private List<string> authors;

        public Book(string title, int year, params string[] authors)
        {
            this.Title = title;
            this.Year = year;
            this.Authors = authors.ToList();
        }

        public string Title
        {
            get { return title; }
            private set { title = value; }
        }
        public int Year
        {
            get { return year; }
            private set { year = value; }
        }
        public List<string> Authors
        {
            get { return authors; }
            set { authors = value; }
        }

        public int CompareTo(Book other)
        {
            if (this.Year < other.Year)
            {
                return -1;
            }
            else if (this.Year > other.Year)
            {
                return 1;
            }

            if (this.Title.First() < other.Title.First())
            {
                return -1;
            }
            else if (this.Title.First() < other.Title.First())
            {
                return 1;
            }

            return 0;
        }

        public override string ToString()
        {
            return $"{this.Title} - {this.Year}";
        }
    }
}
