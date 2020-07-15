using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class Kruskal<TVertex, TWeight> where TWeight : IComparable<TWeight>
    {
        public Kruskal(EdgeWeightedGraph<TVertex, TWeight> graph)
            : this(graph, null) {}

        public Kruskal(EdgeWeightedGraph<TVertex, TWeight> graph, WeightedEdge<TVertex, TWeight> initialMst)
        {
            if (graph == null)
            {
                throw new ArgumentNullException(nameof(graph));
            }

            var edges = new MinPriorityQueue<WeightedEdge<TVertex, TWeight>>(graph.EdgeNumber);
            foreach (var edge in graph.Edges)
            {
                if (!edge.Equals(initialMst))
                {
                    edges.Add(edge);
                }                
            }

            var mst = new UnionFind<TVertex>(graph.Vertices);
            MinimumSpanningTree = new List<WeightedEdge<TVertex, TWeight>>(graph.VertexNumber - 1);
            if (initialMst != null)
            {
                var vertex1 = initialMst.GetVertex();
                var vertex2 = initialMst.GetTheOtherVertex(vertex1);
                mst.Union(vertex1, vertex2);
                MinimumSpanningTree.Add(initialMst);
            }

            while (!edges.IsEmpty && MinimumSpanningTree.Count < graph.VertexNumber - 1)
            {
                var edge = edges.DeleteMin();
                var vertex1 = edge.GetVertex();
                var vertex2 = edge.GetTheOtherVertex(vertex1);
                if (!mst.IsConnected(vertex1, vertex2))
                {
                    mst.Union(vertex1, vertex2);
                    MinimumSpanningTree.Add(edge);
                }
            }

            if (MinimumSpanningTree.Count < graph.VertexNumber - 1)
            {
                throw new ArgumentException();
            }
        }

        public List<WeightedEdge<TVertex, TWeight>> MinimumSpanningTree { get; private set; }
    }
}