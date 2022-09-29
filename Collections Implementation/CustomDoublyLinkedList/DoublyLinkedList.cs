using System;
using System.Collections.Generic;

namespace CustomDoublyLinkedList
{
    class DoublyLinkedList<T>
    {
        public DoublyLinkedList()
        {
        }
        public DoublyLinkedList(ICollection<T> collection)
        {
            foreach (var item in collection)
            {
                this.AddTail(item);
            }
        }

        public int Count { get; private set; }
        public bool IsEmpty => this.Count == 0;
        public LinkedListNode Head { get; set; }
        public LinkedListNode Tail { get; set; }

        public void AddHead(T value)
        {
            if (this.IsEmpty)
            {
                var newNode = new LinkedListNode(value);
                this.Head = this.Tail = newNode;
            }
            else
            {
                var previousHead = this.Head;
                var newNode = new LinkedListNode(value);
                previousHead.Previous = newNode;
                newNode.Next = previousHead;
                this.Head = newNode;
            }

            this.Count++;
        }
        public void AddTail(T value)
        {
            if (this.IsEmpty)
            {
                var newNode = new LinkedListNode(value);
                this.Head = this.Tail = newNode;
            }
            else
            {
                var previousTail = this.Tail;
                var newTail = new LinkedListNode(value);
                previousTail.Next = newTail;
                newTail.Previous = previousTail;
                this.Tail = newTail;
            }

            this.Count++;
        }
        public T RemoveHead()
        {
            if (this.IsEmpty)
            {
                throw new InvalidOperationException("Cannot remove head because DoublyLinkedList is empty!");
            }

            var headToRemove = this.Head;
            var newHead = headToRemove.Next;

            if (newHead == null)
            {
                //there is no new head
                this.Head = this.Tail = null;
            }
            else
            {
                newHead.Previous = null;
                headToRemove.Next = null;

                this.Head = newHead;
            }

            this.Count--;
            return headToRemove.Value;
        }
        public T RemoveTail()
        {
            if (this.IsEmpty)
            {
                throw new InvalidOperationException("Cannot remove tail because DoublyLinkedList is empty!");
            }

            var tailToRemove = this.Tail;
            var newTail = tailToRemove.Previous;

            if (newTail == null)
            {
                //there is no new tail
                this.Head = this.Tail = null;
            }
            else
            {
                tailToRemove.Previous = null;
                newTail.Next = null;

                this.Tail = newTail;
            }

            this.Count--;
            return tailToRemove.Value;
        }
        public void ForEach(Action<T> action)
        {
            var currNode = this.Head;

            while (currNode != null)
            {
                action(currNode.Value);

                currNode = currNode.Next;
            }
        }
        public T[] ToArray()
        {
            var arr = new T[this.Count];
            int counter = 0;

            this.ForEach(number =>
            {
                arr[counter] = number;
                counter++;
            });

            return arr;
        }
        public List<T> ToList()
        {
            var list = new List<T>();

            this.ForEach(n => list.Add(n));
            
            return list;
        }

        public class LinkedListNode
        {
            public LinkedListNode(T value)
            {
                this.Value = value;
            }

            public T Value { get; set; }
            public LinkedListNode Previous { get; set; }
            public LinkedListNode Next { get; set; }
        }
    }
}
