using System;

namespace LeetCode.TheKStrongestValuesInAnArray
{
    public class Solution
    {
        public int[] GetStrongest(int[] arr, int k)
        {
            var median = arr.QuickSelect((arr.Length - 1) / 2, (a, b) => a.CompareTo(b));
            arr.QuickSelect(k - 1, (a, b) =>
            {
                var aStrength = Math.Abs(a - median);
                var bStrength = Math.Abs(b - median);
                if (aStrength == bStrength) return b.CompareTo(a);
                else return bStrength.CompareTo(aStrength);
            });
            var strongest = new int[k--];
            while (k >= 0)
            {
                strongest[k] = arr[k];
                k--;
            }

            return strongest;
        }
    }
}