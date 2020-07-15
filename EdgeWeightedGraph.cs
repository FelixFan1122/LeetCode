using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class EdgeWeightedGraph<TVertex, TWeight> where TWeight : IComparable<TWeight>
    {
        private readonly Dictionary<TVertex, List<WeightedEdge<TVertex, TWeight>>> adjacencyList;

        public EdgeWeightedGraph(int vertexNumber)
        {
            if (vertexNumber < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(vertexNumber));
            }

            adjacencyList = new Dictionary<TVertex, List<WeightedEdge<TVertex, TWeight>>>(vertexNumber);
        }

        public int EdgeNumber { get; private set; }
        public IEnumerable<WeightedEdge<TVertex, TWeight>> Edges
        {
            get
            {
                var set = new HashSet<WeightedEdge<TVertex, TWeight>>(EdgeNumber);
                foreach (var edges in adjacencyList.Values)
                {
                    foreach (var edge in edges)
                    {
                        set.Add(edge);
                    }
                }

                return set;
            }
        }
        public int VertexNumber { get => adjacencyList.Count; }
        public IReadOnlyCollection<TVertex> Vertices { get => adjacencyList.Keys; }

        public void AddEdge(WeightedEdge<TVertex, TWeight> edge)
        {
            if (edge == null)
            {
                throw new ArgumentNullException(nameof(edge));
            }

            var vertex1 = edge.GetVertex();
            var vertex2 = edge.GetTheOtherVertex(vertex1);
            if (!adjacencyList.ContainsKey(vertex1))
            {
                adjacencyList.Add(vertex1, new List<WeightedEdge<TVertex, TWeight>>());
            }

            if (!adjacencyList.ContainsKey(vertex2))
            {
                adjacencyList.Add(vertex2, new List<WeightedEdge<TVertex, TWeight>>());
            }

            adjacencyList[vertex1].Add(edge);
            adjacencyList[vertex2].Add(edge);
            EdgeNumber++;
        }

        public List<WeightedEdge<TVertex, TWeight>> GetEdges(TVertex vertex)
        {
            if (!adjacencyList.ContainsKey(vertex))
            {
                throw new ArgumentOutOfRangeException(nameof(vertex));
            }

            return adjacencyList[vertex];
        }

        public void RemoveEdge(WeightedEdge<TVertex, TWeight> edge)
        {
            if (edge != null)
            {
                var vertex1 = edge.GetVertex();
                var vertex2 = edge.GetTheOtherVertex(vertex1);
                if (adjacencyList.ContainsKey(vertex1) && adjacencyList.ContainsKey(vertex2))
                {
                    adjacencyList[vertex1].Remove(edge);
                    adjacencyList[vertex2].Remove(edge);
                    EdgeNumber--;
                }
            }
        }
    }
}