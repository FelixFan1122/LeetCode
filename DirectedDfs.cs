using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    public class DirectedDfs<T>
    {
        private HashSet<T> marked;
        public DirectedDfs(Digraph<T> digraph, T source)
        {
            if (digraph == null)
            {
                throw new ArgumentNullException(nameof(digraph));
            }

            if (!digraph.Vertices.Contains(source))
            {
                throw new ArgumentOutOfRangeException(nameof(source));
            }

            marked = new HashSet<T>(digraph.VertexNumber);

            Dfs(digraph, source);
        }

        public DirectedDfs(Digraph<T> digraph, IEnumerable<T> sources)
        {
            if (digraph == null)
            {
                throw new ArgumentNullException(nameof(digraph));
            }

            marked = new HashSet<T>(digraph.VertexNumber);
            foreach (var source in sources.Intersect(digraph.Vertices))
            {
                Dfs(digraph, source);
            }
        }

        public bool IsMarked(T vertex)
        {
            return marked.Contains(vertex);
        }

        private void Dfs(Digraph<T> digraph, T vertex)
        {
            if (!marked.Contains(vertex))
            {
                marked.Add(vertex);
                foreach (var neighbour in digraph.GetNeighbours(vertex))
                {
                    Dfs(digraph, neighbour);
                }
            }
        }
    }
}