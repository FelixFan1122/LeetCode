using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class MinPriorityQueue<T> where T : IComparable<T>
    {
        private const int Capacity = 1;
        private T[] minPriorityQueue;
        public MinPriorityQueue() : this(Capacity) { }

        public MinPriorityQueue(int capacity)
        {
            minPriorityQueue = new T[capacity + 1];
        }

        public MinPriorityQueue(IEnumerable<T> elements)
        {
            throw new NotImplementedException();
        }

        public bool IsEmpty
        {
            get
            {
                return Count == 0;
            }
        }

        public T Min
        {
            get
            {
                if (Count == 0)
                {
                    throw new InvalidOperationException();
                }

                return minPriorityQueue[1];
            }
        }

        public int Count { get; private set; }

        public void Add(T element)
        {
            if (Count == minPriorityQueue.Length - 1)
            {
                Resize(minPriorityQueue.Length * 2);
            }

            Count++;
            minPriorityQueue[Count] = element;
            Swim(Count);
        }

        public T DeleteMin()
        {
            var min = minPriorityQueue[1];
            minPriorityQueue[1] = minPriorityQueue[Count];
            minPriorityQueue[Count] = default(T);
            Count--;
            Sink(1);
            if (Count > 0 && Count == minPriorityQueue.Length / 4 - 1)
            {
                Resize(minPriorityQueue.Length / 2);
            }

            return min;
        }

        private void Resize(int size)
        {
            var resized = new T[size];
            for (var i = 1; i <= Count; i++)
            {
                resized[i] = minPriorityQueue[i];
            }

            minPriorityQueue = resized;
        }

        private void Sink(int index)
        {
            var leftChild = index * 2;
            var rightChild = leftChild + 1;
            int smaller;
            T temp;
            while ((leftChild <= Count && minPriorityQueue[leftChild].CompareTo(minPriorityQueue[index]) < 0) ||
                (rightChild <= Count && minPriorityQueue[rightChild].CompareTo(minPriorityQueue[index]) < 0))
            {
                smaller = minPriorityQueue[leftChild].CompareTo(minPriorityQueue[rightChild]) < 0 ? leftChild : rightChild;
                temp = minPriorityQueue[smaller];
                minPriorityQueue[smaller] = minPriorityQueue[index];
                minPriorityQueue[index] = temp;
                index = smaller;
                leftChild = index * 2;
                rightChild = leftChild + 1;
            }
        }

        private void Swim(int index)
        {
            var parent = index / 2;
            T temp;
            while (index != 1 && minPriorityQueue[index].CompareTo(minPriorityQueue[parent]) < 0)
            {
                temp = minPriorityQueue[parent];
                minPriorityQueue[parent] = minPriorityQueue[index];
                minPriorityQueue[index] = temp;
                index = parent;
                parent = index / 2;
            }
        }
    }
}