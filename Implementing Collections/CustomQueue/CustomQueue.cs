using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CustomQueue
{
    public class CustomQueue<T>
    {
        public CustomQueue() : this(4)
        {

        }
        public CustomQueue(int capacity)
        {
            this.Capacity = capacity;
            this.items = new T[capacity];
        }
        public CustomQueue(ICollection<T> collection) : this(4)
        {
            this.items = collection.ToArray();
            this.Count = this.items.Length;
            this.ResizeInternal();
        }

        //Internal fields
        private T[] items;

        //Public Properties
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
        private void ShrinkInternal()
        {
            while (this.Capacity >= this.Count * 4)
            {
                this.Capacity /= 2;
            }

            var newCollection = new T[this.Capacity];

            for (int i = 0; i < this.Count; i++)
            {
                newCollection[i] = this.items[i];
            }

            items = newCollection;
        }
        private void ShiftLeft()
        {
            for (int i = 0; i < this.Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }

            this.items[this.Count - 1] = default(T);
        }

        //Public methods
        public void Enqueue(T element)
        {
            if (this.Count >= this.Capacity)
            {
                this.ResizeInternal();
            }

            this.items[this.Count] = element;
            this.Count++;
        }
        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("CustomQueue is empty!");
            }

            var itemToRemove = items[0];
            this.ShiftLeft();
            this.Count--;

            if (this.Count <= this.Capacity / 4)
            {
                this.ShrinkInternal();
            }

            return itemToRemove;
        }
        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("CustomQueue is empty!");
            }

            var element = this.items[0];
            return element;
        }
        public void Clear()
        {
            this.Capacity = 4;
            this.Count = 0;
            this.items = new T[Capacity];
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
