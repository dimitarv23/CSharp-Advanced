using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P02.Collection
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> items;
        private int internalIndex;

        public ListyIterator(params T[] collection)
        {
            this.items = collection.ToList();
            this.internalIndex = 0;
        }

        public bool Move()
        {
            if (internalIndex + 1 >= items.Count)
            {
                return false;
            }

            internalIndex++;
            return true;
        }
        public bool HasNext()
        {
            if (internalIndex + 1 >= items.Count)
            {
                return false;
            }

            return true;
        }
        public void Print()
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(this.items[this.internalIndex]);
        }

        public void PrintAll()
        {
            foreach (var item in this.items)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                yield return this.items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
