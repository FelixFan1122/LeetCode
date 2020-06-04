using System.Collections.Generic;

namespace LeetCode.CloneGraph
{
    public class Node
    {
        public int val;
        public IList<Node> neighbors;

        public Node() { }
        public Node(int _val, IList<Node> _neighbors)
        {
            val = _val;
            neighbors = _neighbors;
        }
    }

    public class Solution
    {
        public Node CloneGraph(Node node)
        {
            if (node == null)
            {
                return null;
            }

            var clones = new Dictionary<int, Node>();
            var visited = new HashSet<int>();
            var bfsQueue = new Queue<Node>();
            bfsQueue.Enqueue(node);
            while (bfsQueue.Count > 0)
            {
                var workItem = bfsQueue.Dequeue();
                if (visited.Contains(workItem.val))
                {
                    continue;
                }

                if (!clones.ContainsKey(workItem.val))
                {
                    clones.Add(workItem.val, new Node(workItem.val, new List<Node>()));
                }

                var clone = clones[workItem.val];
                foreach (var neighbor in workItem.neighbors)
                {
                    if (!clones.ContainsKey(neighbor.val))
                    {
                        clones.Add(neighbor.val, new Node(neighbor.val, new List<Node>()));
                    }

                    var neighborClone = clones[neighbor.val];
                    clone.neighbors.Add(neighborClone);

                    if (!visited.Contains(neighbor.val))
                    {
                        bfsQueue.Enqueue(neighbor);
                    }
                }

                visited.Add(workItem.val);
            }

            return clones[node.val];
        }
    }
}