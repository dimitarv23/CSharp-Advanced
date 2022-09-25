using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private List<Book> books;

        public Library(params Book[] books)
        {
            this.books = books.ToList();
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(this.books);
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private class LibraryIterator : IEnumerator<Book>
        {
            private readonly List<Book> books;
            private int currIndex;

            public LibraryIterator(IEnumerable<Book> books)
            {
                Reset();
                this.books = books.ToList();
            }

            public Book Current => this.books[this.currIndex];
            object IEnumerator.Current => this.Current;

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                this.currIndex++;
                return currIndex < this.books.Count;
            }

            public void Reset()
            {
                this.currIndex = -1;
            }
        }
    }
}
