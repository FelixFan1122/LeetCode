using System;
using System.Collections.Generic;

namespace LeetCode.QuickSelect
{
    public static class QuickSelect
    {
        public static T Select<T>(IList<T> list, int left, int right, int k) where T : IComparable<T>
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }

            if (left < 0 || left > right || right >= list.Count || k > right - left + 1)
            {
                throw new ArgumentOutOfRangeException();
            }

            k += left - 1;
            var rand = new Random();
            while (left <= right)
            {
                var pivot = rand.Next(left, right + 1);
                pivot = Partition(list, left, right, pivot);
                if (pivot == k)
                {
                    return list[pivot];
                }
                else if (pivot > k)
                {
                    right = pivot - 1;
                }
                else
                {
                    left = pivot + 1;
                }
            }

            throw new ApplicationException();
        }

        private static int Partition<T>(IList<T> list, int left, int right, int pivot) where T : IComparable<T>
        {
            Swap(list, pivot, right);

            var store = left;
            for (var i = left; i < right; i++)
            {
                if (list[i].CompareTo(list[right]) < 0)
                {
                    Swap(list, store++, i);
                }
            }

            Swap(list, store, right);

            return store;
        }

        private static void Swap<T>(IList<T> list, int index1, int index2)
        {
            var temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
        }
    }
}