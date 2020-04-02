using System;

namespace LeetCode.ShuffleAnArray
{
    public class Solution
    {
        private int[] original;
        public Solution(int[] nums)
        {
            original = nums;
        }

        /** Resets the array to its original configuration and return it. */
        public int[] Reset()
        {
            return original;
        }

        /** Returns a random shuffling of the array. */
        public int[] Shuffle()
        {
            var shuffled = new int[original.Length];
            for (var i = 0; i < shuffled.Length; i++)
            {
                shuffled[i] = original[i];
            }

            var rand = new Random();
            for (var i = 0; i < shuffled.Length - 1; i++)
            {
                var j = rand.Next(i, shuffled.Length);
                var temp = shuffled[i];
                shuffled[i] = shuffled[j];
                shuffled[j] = temp;
            }

            return shuffled;
        }
    }
}