using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomStack
{
    public class CustomStack<T>
    {
        public CustomStack() : this(2)
        {
        }
        public CustomStack(int capacity)
        {
            this.Capacity = capacity;
            this.items = new T[capacity];
        }
        public CustomStack(ICollection<T> collection) : this(2)
        {
            this.items = collection.ToArray();
            this.Count = items.Length;
            ResizeInternal();
        }

        //Internal fields
        private T[] items;

        //Public properties
        public int Count { get; private set; }
        public int Capacity { get; private set; }

        //Private methods
        private void ResizeInternal()
        {
            while (this.Capacity <= this.Count)
            {
                this.Capacity *= 2;
            }

            var newCollection = new T[this.Capacity];

            for (int i = 0; i < this.Count; i++)
            {
                newCollection[i] = this.items[i];
            }

            items = newCollection;
        }

        //Public methods
        public void Push(T element)
        {
            if (this.Count >= this.Capacity)
            {
                ResizeInternal();
            }

            this.items[this.Count] = element;
            this.Count++;
        }
        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("CustomStack is empty!");
            }

            var itemToRemove = this.items[this.Count - 1];
            this.items[this.Count - 1] = default(T);
            this.Count--;

            return itemToRemove;
        }
        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("CustomStack is empty!");
            }

            return items[this.Count - 1];
        }
        public void ForEach(Action<T> action)
        {
            for (int i = 0; i < this.Count; i++)
            {
                action(this.items[i]);
            }
        }
    }
}
