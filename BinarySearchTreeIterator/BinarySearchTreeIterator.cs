using System;
using System.Collections.Generic;

namespace LeetCode.BinarySearchTreeIterator
{
    public class BSTIterator
    {
        private Stack<TreeNode> path;

        public BSTIterator(TreeNode root)
        {
            path = new Stack<TreeNode>();
            while (root != null)
            {
                path.Push(root);
                root = root.left;
            }
        }

        public int Next()
        {
            if (path == null)
            {
                throw new InvalidOperationException();
            }

            var min = path.Pop();
            if (min.right != null)
            {
                var node = min.right;
                while (node != null)
                {
                    path.Push(node);
                    node = node.left;
                }
            }

            return min.val;
        }

        public bool HasNext()
        {
            return path.Count > 0;
        }
    }
}