using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    public class Book
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
            int result = this.Year.CompareTo(other.Year);

            if (result == 0)
            {
                result = this.Title.CompareTo(other.Title);
            }

            return result;
        }

        public override string ToString()
        {
            return $"{this.Title} - {this.Year}";
        }
    }
}
