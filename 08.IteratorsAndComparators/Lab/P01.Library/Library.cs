using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library
    {
        private List<Book> books;

        public Library(params Book[] books)
        {
            this.Books = books.ToList();
        }

        public List<Book> Books
        {
            get { return books; }
            set { books = value; }
        }
    }
}
