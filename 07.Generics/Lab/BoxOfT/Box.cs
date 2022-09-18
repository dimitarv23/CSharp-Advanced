using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        public Box()
        {
            this.Items = new List<T>();
            this.Count = 0;
        }

        public List<T> Items;
        public int Count { get; private set; }

        public void Add(T item)
        {
            this.Items.Add(item);
            this.Count++;
        }
        public T Remove()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Box is empty!");
            }

            var removed = this.Items.Last();
            this.Items.RemoveAt(this.Count - 1);
            this.Count--;

            return removed;
        }
    }
}
