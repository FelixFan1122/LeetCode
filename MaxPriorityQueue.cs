using System;
using System.Collections.Generic;

public class MaxPriorityQueue<T> where T : IComparable<T>
{
    private T[] maxPriorityQueue;
    public MaxPriorityQueue()
    {
        throw new NotImplementedException();
    }

    public MaxPriorityQueue(int capacity)
    {
        maxPriorityQueue = new T[capacity + 1];
    }

    public MaxPriorityQueue(IEnumerable<T> elements)
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

    public T Max
    {
        get
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            return maxPriorityQueue[1];
        }
    }

    public int Count { get; private set; }

    public void Add(T element)
    {
        Count++;
        maxPriorityQueue[Count] = element; // TODO: Implement array resizing.
        Swim(Count);
    }

    public T DeleteMax()
    {
        var max = maxPriorityQueue[1];
        maxPriorityQueue[1] = maxPriorityQueue[Count];
        maxPriorityQueue[Count] = default(T);
        Count--; // TODO: Implement array resizing;
        Sink(1);

        return max;
    }

    private void Sink(int index)
    {
        var leftChild = index * 2;
        var rightChild = leftChild + 1;
        int larger;
        T temp;
        while ((leftChild <= Count && maxPriorityQueue[leftChild].CompareTo(maxPriorityQueue[index]) > 0) ||
            (rightChild <= Count && maxPriorityQueue[rightChild].CompareTo(maxPriorityQueue[index]) > 0))
        {
            larger = leftChild > rightChild ? leftChild : rightChild;
            temp = maxPriorityQueue[larger];
            maxPriorityQueue[larger] = maxPriorityQueue[index];
            maxPriorityQueue[index] = temp;
            index = larger;
            leftChild = index * 2;
            rightChild = leftChild + 1;
        }
    }

    private void Swim(int index)
    {
        var parent = index / 2;
        T temp;
        while (index != 1 && maxPriorityQueue[index].CompareTo(maxPriorityQueue[parent]) > 0)
        {
            temp = maxPriorityQueue[parent];
            maxPriorityQueue[parent] = maxPriorityQueue[index];
            maxPriorityQueue[index] = temp;
            index = parent;
            parent = index / 2;
        }
    }
}