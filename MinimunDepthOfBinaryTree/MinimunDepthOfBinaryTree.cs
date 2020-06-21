using System.Collections.Generic;

namespace LeetCode.MinimunDepthOfBinaryTree
{
    public class Solution
    {
        public int MinDepth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            var toVisit = new Queue<KeyValuePair<TreeNode, int>>();
            toVisit.Enqueue(new KeyValuePair<TreeNode, int>(root, 1));
            while (toVisit.Count > 0)
            {
                var item = toVisit.Dequeue();
                var node = item.Key;
                var depth = item.Value;
                if (node.left == null && node.right == null)
                {
                    return depth;
                }

                if (node.left != null)
                {
                    toVisit.Enqueue(new KeyValuePair<TreeNode, int>(node.left, depth + 1));
                }

                if (node.right != null)
                {
                    toVisit.Enqueue(new KeyValuePair<TreeNode, int>(node.right, depth + 1));
                }
            }

            return 0;
        }
    }
}