using System;
using System.Collections.Generic;

namespace CourseScheduleII
{
    public class Solution
    {
        public int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            var courses = new List<int>();
            if (prerequisites != null)
            {
                var digraph = new Digraph<int>();
                foreach (var prerequisite in prerequisites)
                {
                    digraph.AddEdge(prerequisite[1], prerequisite[0]);
                }

                var order = new Topological<int>(digraph).Order;
                if (order == null && prerequisites.Length > 0)
                {
                    return new int[0];
                }

                if (order != null)
                {
                    foreach (var course in order)
                    {
                        courses.Add(course);
                    }
                }
            }

            while (numCourses-- > 0)
            {
                if (!courses.Contains(numCourses))
                {
                    courses.Add(numCourses);
                }
            }

            return courses.ToArray();
        }
    }

    public class Topological<T>
    {
        public Topological(Digraph<T> digraph)
        {
            if (digraph == null)
            {
                throw new ArgumentNullException(nameof(digraph));
            }

            if (!new DirectedCycle<T>(digraph).HasCycle)
            {
                Order = new DepthFirstOrder<T>(digraph).ReversePostOrder;
            }
        }

        public IEnumerable<T> Order { get; private set; }
    }

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

            var visited = new HashSet<T>();
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

    public class DirectedCycle<T>
    {
        private Stack<T> cycle;
        public DirectedCycle(Digraph<T> digraph)
        {
            if (digraph == null)
            {
                throw new ArgumentNullException(nameof(digraph));
            }

            var currentPath = new HashSet<T>();
            var edgeTo = new Dictionary<T, T>();
            var visited = new HashSet<T>();
            foreach (var vertex in digraph.Vertices)
            {
                if (!visited.Contains(vertex))
                {
                    DepthFirstTraverse(digraph, vertex, visited, currentPath, edgeTo);
                }
            }
        }

        public IEnumerable<T> Cycle
        {
            get
            {
                return cycle;
            }
        }

        public bool HasCycle
        {
            get
            {
                return cycle != null;
            }
        }

        private void DepthFirstTraverse(Digraph<T> digraph, T vertex, HashSet<T> visited, HashSet<T> currentPath, Dictionary<T, T> edgeTo)
        {
            currentPath.Add(vertex);
            visited.Add(vertex);
            foreach (var neighbour in digraph.GetNeighbours(vertex))
            {
                if (HasCycle)
                {
                    return;
                }

                if (!visited.Contains(neighbour))
                {
                    edgeTo.Add(neighbour, vertex);
                    DepthFirstTraverse(digraph, neighbour, visited, currentPath, edgeTo);
                }
                else if (currentPath.Contains(neighbour))
                {
                    cycle = new Stack<T>();
                    var current = vertex;
                    while (!current.Equals(neighbour))
                    {
                        cycle.Push(current);
                        current = edgeTo[current];
                    }

                    cycle.Push(neighbour);
                    cycle.Push(vertex);
                }
            }

            currentPath.Remove(vertex);
        }
    }

    public class Digraph<T>
    {
        private readonly Dictionary<T, List<T>> adjacencyList = new Dictionary<T, List<T>>();

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
            if (!adjacencyList.ContainsKey(from))
            {
                adjacencyList.Add(from, new List<T>());
            }

            adjacencyList[from].Add(to);
        }

        public IEnumerable<T> GetNeighbours(T vertex)
        {
            return adjacencyList.ContainsKey(vertex) ? adjacencyList[vertex] : new List<T>();
        }
    }
}