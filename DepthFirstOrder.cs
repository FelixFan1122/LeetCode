using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class DepthFirstOrder<T>
    {
        private Queue<T> postOrder;
        private Queue<T> preOrder;
        private Stack<T> reversePostOrder;
        public DepthFirstOrder(Digraph<T> digraph)
        {
            if (digraph == null)
            {
                throw new ArgumentNullException(nameof(digraph));
            }

            postOrder = new Queue<T>(digraph.VertexNumber);
            preOrder = new Queue<T>(digraph.VertexNumber);
            reversePostOrder = new Stack<T>(digraph.VertexNumber);

            var visited = new HashSet<T>(digraph.VertexNumber);
            foreach (var vertex in digraph.Vertices)
            {
                if (!visited.Contains(vertex))
                {
                    DepthFirstTraverse(digraph, vertex, visited);
                }
            }
        }

        public IEnumerable<T> PostOrder
        {
            get
            {
                return postOrder;
            }
        }

        public IEnumerable<T> PreOrder
        {
            get
            {
                return preOrder;
            }
        }

        public IEnumerable<T> ReversePostOrder
        {
            get
            {
                return reversePostOrder;
            }
        }

        private void DepthFirstTraverse(Digraph<T> digraph, T vertex, HashSet<T> visited)
        {
            preOrder.Enqueue(vertex);

            visited.Add(vertex);
            foreach (var neighbour in digraph.GetNeighbours(vertex))
            {
                if (!visited.Contains(neighbour))
                {
                    DepthFirstTraverse(digraph, neighbour, visited);
                }
            }

            postOrder.Enqueue(vertex);
            reversePostOrder.Push(vertex);
        }
    }
}