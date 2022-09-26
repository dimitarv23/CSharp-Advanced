using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace P03.Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        private List<T> items;

        public Stack()
        {
            this.items = new List<T>();
        }

        public void Push(params T[] values)
        {
            foreach (var item in values)
            {
                items.Add(item);
            }
        }
        public void Pop()
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException("No elements");
            }

            items.RemoveAt(items.Count - 1);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = items.Count - 1; i >= 0; i--)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
