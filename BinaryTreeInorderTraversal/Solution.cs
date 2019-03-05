using System.Collections.Generic;
using System.Linq;

namespace LeetCode.BinaryTreeInorderTraversal
{
    public class Solution {
        public IList<int> InorderTraversal(TreeNode root) {
            if (root == null)
            {
                return new int[0];
            }

            // Call the real procedure to produce the outcome expected by the problem statements.
            // Sacrificed lazy loading though.
            return InorderTraversalIterative(root).ToList();
        }

        private IEnumerable<int> InorderTraversalIterative(TreeNode treeNode)
        {
            var processed = new HashSet<TreeNode>();
            var nodes = new Stack<TreeNode>();
            nodes.Push(treeNode);
            while (nodes.Count > 0)
            {
                var node = nodes.Pop();
                if (node.left != null && !processed.Contains(node.left))
                {
                    nodes.Push(node);
                    nodes.Push(node.left);
                }
                else
                {
                    processed.Add(node);
                    yield return node.val;
                    if (node.right != null)
                    {
                        nodes.Push(node.right);
                    }
                }
            }
        }
    }
}