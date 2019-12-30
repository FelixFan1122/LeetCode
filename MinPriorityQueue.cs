using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class MinPriorityQueue<T> where T : IComparable<T>
    {
        private T[] minPriorityQueue;
        public MinPriorityQueue()
        {
            throw new NotImplementedException();
        }

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
            Count++;
            minPriorityQueue[Count] = element; // TODO: Implement array resizing.
            Swim(Count);
        }

        public T DeleteMin()
        {
            var min = minPriorityQueue[1];
            minPriorityQueue[1] = minPriorityQueue[Count];
            minPriorityQueue[Count] = default(T);
            Count--; // TODO: Implement array resizing;
            Sink(1);

            return min;
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