using System;

namespace LeetCode.FindMedianFromDataStream
{
    public class MedianFinder
    {
        private readonly MaxPriorityQueue<int> maxHeap;
        private readonly MinPriorityQueue<int> minHeap;
        public MedianFinder()
        {
            maxHeap = new MaxPriorityQueue<int>();
            minHeap = new MinPriorityQueue<int>();
        }

        public void AddNum(int num)
        {
            if (maxHeap.Count == 0 || num < maxHeap.Max)
            {
                maxHeap.Add(num);
            }
            else
            {
                minHeap.Add(num);
            }

            if (maxHeap.Count < minHeap.Count)
            {
                maxHeap.Add(minHeap.DeleteMin());
            }
            else if (maxHeap.Count > minHeap.Count + 1)
            {
                minHeap.Add(maxHeap.DeleteMax());
            }
        }

        public double FindMedian()
        {
            if (maxHeap.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return maxHeap.Count == minHeap.Count ? (maxHeap.Max + minHeap.Min) / 2.0 : maxHeap.Max;
        }
    }
}