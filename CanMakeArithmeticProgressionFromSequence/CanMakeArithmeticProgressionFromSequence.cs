using System;

namespace LeetCode.CanMakeArithmeticProgressionFromSequence
{
    public class Solution
    {
        public bool CanMakeArithmeticProgression(int[] arr)
        {
            int min = int.MaxValue, max = int.MinValue;
            for (var i = 0; i < arr.Length; i++)
            {
                min = Math.Min(min, arr[i]);
                max = Math.Max(max, arr[i]);
            }
            if ((max - min) % (arr.Length - 1) != 0) return false;
            var diff = (max - min) / (arr.Length - 1);
            for (var i = 0; i < arr.Length; i++)
            {
                if (arr[i] == min + diff * i) continue;
                var current = arr[i];
                while (current != min + diff * i)
                {
                    if ((current - min) % diff != 0) return false;
                    var temp = arr[(current - min) / diff];
                    if (temp == current) return false;
                    arr[(current - min) / diff] = current;
                    current = temp;
                }
                arr[i] = current;
            }
            return true;
        }
    }
}