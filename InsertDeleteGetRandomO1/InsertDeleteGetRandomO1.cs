using System;
using System.Collections.Generic;

namespace LeetCode.InsertDeleteGetRandomO1
{
    public class RandomizedSet
    {
        private List<int> set;
        private Dictionary<int, int> indices;
        private Random rand;
        /** Initialize your data structure here. */
        public RandomizedSet()
        {
            set = new List<int>();
            indices = new Dictionary<int, int>();
            rand = new Random();
        }

        /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
        public bool Insert(int val)
        {
            if (indices.ContainsKey(val))
            {
                return false;
            }

            indices[val] = set.Count;
            set.Add(val);

            return true;
        }

        /** Removes a value from the set. Returns true if the set contained the specified element. */
        public bool Remove(int val)
        {
            if (!indices.ContainsKey(val))
            {
                return false;
            }

            var index = indices[val];
            indices[set[set.Count - 1]] = index;
            indices.Remove(val);
            set[index] = set[set.Count - 1];
            set.RemoveAt(set.Count - 1);

            return true;
        }

        /** Get a random element from the set. */
        public int GetRandom()
        {
            if (set.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return set[rand.Next(set.Count)];
        }
    }
}