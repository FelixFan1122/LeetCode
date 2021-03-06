using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class Digraph<T>
    {
        private readonly Dictionary<T, List<T>> adjacencyList;

        public Digraph()
        {
            adjacencyList = new Dictionary<T, List<T>>();
        }

        public Digraph(int capacity)
        {
            adjacencyList = new Dictionary<T, List<T>>(capacity);
        }

        public int VertexNumber
        {
            get
            {
                return adjacencyList.Count;
            }
        }

        public IEnumerable<T> Vertices
        {
            get
            {
                return adjacencyList.Keys;
            }
        }

        public void AddEdge(T from, T to)
        {
            AddVertex(from);
            AddVertex(to);

            adjacencyList[from].Add(to);
        }

        public void AddVertex(T vertex)
        {
            if (!adjacencyList.ContainsKey(vertex))
            {
                adjacencyList.Add(vertex, new List<T>());
            }
        }

        public IEnumerable<T> GetNeighbours(T vertex)
        {
            if (!adjacencyList.ContainsKey(vertex))
            {
                throw new ArgumentException();
            }

            return adjacencyList[vertex];
        }
    }
}