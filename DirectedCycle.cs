using System;
using System.Collections.Generic;

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