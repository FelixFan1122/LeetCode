using System;
using System.Collections.Generic;

namespace LeetCode
{
    public static class QuickSelectExtension
    {
        public static T QuickSelect<T>(this IList<T> list, int k, Func<T, T, int> compare)
        {
            if (list == null) throw new ArgumentNullException(nameof(list));
            if (k < 0 || k > list.Count) throw new ArgumentOutOfRangeException(nameof(k));
            var left = 0;
            var right = list.Count - 1;
            while (left < right)
            {
                var pivot = MedianOfThree(list, left, right, compare);
                pivot = LomutoPartition(list, left, right, pivot, compare);
                if (pivot == k) return list[pivot];
                else if (pivot < k) left = pivot + 1;
                else right = pivot - 1;
            }

            return list[left];
        }

        private static int LomutoPartition<T>(IList<T> list, int left, int right, int pivotIndex, Func<T, T, int> compare)
        {
            var pivot = list[pivotIndex];
            Swap(list, pivotIndex, right);
            var index = left;
            for (var i = left; i < right; i++)
            {
                if (compare(list[i], pivot) < 0) Swap(list, index++, i);
            }

            Swap(list, index, right);
            return index;
        }

        private static int MedianOfThree<T>(IList<T> list, int left, int right, Func<T, T, int> compare)
        {
            var mid = left + (right - left) / 2;
            if (compare(list[left], list[mid]) > 0) Swap(list, left, mid);
            if (compare(list[left], list[right]) > 0) Swap(list, left, right);
            if (compare(list[mid], list[right]) > 0) Swap(list, mid, right);
            return mid;
        }

        private static void Swap<T>(IList<T> list, int index1, int index2)
        {
            var temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
        }
    }
}