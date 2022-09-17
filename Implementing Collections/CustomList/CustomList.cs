using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CustomList
{
    public class CustomList<T>
    {
        public CustomList() : this(2)
        {
        }
        public CustomList(int capacity)
        {
            if (capacity <= 0)
            {
                throw new Exception("CustomList cannot have a negative or equal to 0 capacity!");
            }

            this.Capacity = capacity;
            items = new T[capacity];
        }
        public CustomList(ICollection<T> collection) : this(2)
        {
            items = collection.ToArray();
            this.Count = items.Length;

            this.ResizeInternal();
        }

        //Internal fields
        private T[] items;

        //Public properties
        public int Capacity { get; private set; }
        public int Count { get; private set; }
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return items[index];
            }
            set
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException();
                }

                items[index] = value;
            }
        }

        //Internal methods
        private void ResizeInternal()
        {
            while (this.Capacity <= this.Count)
            {
                this.Capacity *= 2;
            }

            var newCollection = new T[this.Capacity];

            for (int i = 0; i < this.items.Length; i++)
            {
                newCollection[i] = items[i];
            }

            this.items = newCollection;
        }
        private void ShiftLeft(int index)
        {
            for (int i = index; i < this.Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }
        }
        private void ShiftRight(int index)
        {
            for (int i = this.Count; i > index; i--)
            {
                this.items[i] = this.items[i - 1];
            }
        }
        private void Shrink()
        {
            this.Capacity /= 2;
            var newCollection = new T[this.Capacity / 2];

            for (int i = 0; i < this.Count; i++)
            {
                newCollection[i] = items[i];
            }

            this.items = newCollection;
        }

        //Public methods
        public void Add(T item)
        {
            if (this.Count == this.items.Length)
            {
                this.ResizeInternal();
            }

            this.items[this.Count] = item;
            this.Count++;
        }
        public T RemoveAt(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            var itemToRemove = items[index];
            this.ShiftLeft(index);
            this.Count--;

            if (this.Count <= this.Capacity / 4)
            {
                this.Shrink();
            }

            return itemToRemove;
        }
        public void Insert(int index, T item)
        {
            if (index < 0 || index > this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (this.Count == this.Capacity)
            {
                this.ResizeInternal();
            }

            this.ShiftRight(index);
            this.items[index] = item;
            this.Count++;
        }
        public bool Contains(T searched)
        {
            foreach (var item in items)
            {
                if (item.Equals(searched))
                {
                    return true;
                }
            }

            return false;
        }
        public void Swap(int firstIndex, int secondIndex)
        {
            if (firstIndex < 0 || firstIndex >= this.Count
                || secondIndex < 0 || secondIndex >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            var firstItem = items[firstIndex];
            items[firstIndex] = items[secondIndex];
            items[secondIndex] = firstItem;
        }
        public void Clear()
        {
            this.Capacity = 2;
            var newCollection = new T[this.Capacity];
            this.items = newCollection;
            this.Count = 0;
        }

    }
}
