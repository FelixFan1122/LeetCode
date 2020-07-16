using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.FindCriticalAndPseudoCriticalEdgesInMinimumSpanningTree
{
    public class Solution
    {
        public IList<IList<int>> FindCriticalAndPseudoCriticalEdges(int n, int[][] edges)
        {
            var graph = new EdgeWeightedGraph<int, int>(n);
            for (var i = 0; i < edges.Length; i++) graph.AddEdge(new WeightedEdge<int, int>(edges[i][0], edges[i][1], edges[i][2], i));
            var kruskal = new Kruskal<int, int>(graph);
            var mst = kruskal.MinimumSpanningTree;
            var weight = mst.Sum(edge => edge.Weight);
            var criticals = new HashSet<WeightedEdge<int, int>>();
            foreach (var edge in mst)
            {
                graph.RemoveEdge(edge);
                try {
                    if (new Kruskal<int, int>(graph).MinimumSpanningTree.Sum(edge => edge.Weight) > weight) criticals.Add(edge);
                }
                catch (ArgumentException) {
                    criticals.Add(edge);
                }
                graph.AddEdge(edge);
            }

            var pseudos = new List<WeightedEdge<int, int>>();
            foreach (var edge in graph.Edges) if (!criticals.Contains(edge) && new Kruskal<int, int>(graph, edge).MinimumSpanningTree.Sum(edge => edge.Weight) == weight) pseudos.Add(edge);
            var result0 = new List<int>(criticals.Count);
            var result1 = new List<int>(pseudos.Count);
            result0.AddRange(criticals.Select(edge => edge.Id));
            result1.AddRange(pseudos.Select(edge => edge.Id));
            return new List<IList<int>>(2) { result0, result1 };
        }
    }
}