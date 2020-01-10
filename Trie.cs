using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class Trie<T> : IStringSymbolTable<T>
    {
        private const int Radix = 256;

        private Node root;

        public IEnumerable<string> Keys => throw new System.NotImplementedException();

        public bool IsEmpty => throw new System.NotImplementedException();

        public int Size => throw new System.NotImplementedException();

        public bool Contains(string key)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(string key)
        {
            throw new System.NotImplementedException();
        }

        public T Get(string key)
        {
            var node = Get(root, key, 0);
            return node == null ? default(T) : node.val;
        }

        public IEnumerable<string> GetKeysOfPrefix(string prefix)
        {
            var keys = new Queue<string>();
            Collect(Get(root, prefix, 0), prefix, keys);
            return keys;
        }

        public IEnumerable<string> GetKeysThatMatch(string pattern)
        {
            throw new System.NotImplementedException();
        }

        public string GetLongestPrefixOf(string word)
        {
            throw new System.NotImplementedException();
        }

        public void Put(string key, T val)
        {
            root = Put(root, key, val, 0);
        }

        private void Collect(Node node, string current, Queue<string> keys)
        {
            if (node == null)
            {
                return;
            }

            if (!node.val.Equals(default(T)))
            {
                keys.Enqueue(current);
            }

            for (char c = (char)0; c < Radix; c++)
            {
                Collect(node.next[c], current + c, keys);
            }
        }

        private Node Get(Node node, string key, int index)
        {
            if (node == null)
            {
                return null;
            }

            if (index == key.Length)
            {
                return node;
            }

            return Get(node.next[key[index]], key, index + 1);
        }

        private Node Put(Node node, string key, T val, int index)
        {
            if (node == null)
            {
                node = new Node();
            }

            if (index == key.Length)
            {
                node.val = val;
                return node;
            }

            node.next[key[index]] = Put(node.next[key[index]], key, val, index + 1);

            return node;
        }

        private class Node
        {
            public T val;
            public Node[] next = new Node[Radix];
        }
    }
}