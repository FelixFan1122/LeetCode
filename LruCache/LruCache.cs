using System.Collections.Generic;

namespace LeetCode.LruCache
{
    public class LRUCache
    {
        private const int NotFound = -1;

        private Dictionary<int, LinkedListNode<KeyValuePair<int, int>>> cache;
        private int capacity;
        private LinkedList<KeyValuePair<int, int>> sequence;
        public LRUCache(int capacity)
        {
            this.capacity = capacity;
            cache = new Dictionary<int, LinkedListNode<KeyValuePair<int, int>>>(capacity);
            sequence = new LinkedList<KeyValuePair<int, int>>();
        }

        public int Get(int key)
        {
            if (!cache.ContainsKey(key))
            {
                return NotFound;
            }

            var node = cache[key];
            sequence.Remove(node);
            sequence.AddFirst(node);

            return node.Value.Value;
        }

        public void Put(int key, int value)
        {
            if (cache.ContainsKey(key))
            {
                var node = cache[key];
                sequence.Remove(node);
                node = new LinkedListNode<KeyValuePair<int, int>>(new KeyValuePair<int, int>(key, value));
                sequence.AddFirst(node);
                cache[key] = node;
            }
            else
            {
                if (cache.Count == capacity)
                {
                    cache.Remove(sequence.Last.Value.Key);
                    sequence.RemoveLast();
                }

                var node = new LinkedListNode<KeyValuePair<int, int>>(new KeyValuePair<int, int>(key, value));
                sequence.AddFirst(node);
                cache[key] = node;
            }
        }
    }
}