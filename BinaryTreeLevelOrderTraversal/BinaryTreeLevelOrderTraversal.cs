using System.Collections.Generic;

namespace LeetCode.BinaryTreeLevelOrderTraversal
{
    public class Solution
    {
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            var levels = new List<IList<int>>();
            if (root == null)
            {
                return levels;
            }

            var parents = new Queue<TreeNode>();
            var children = new Queue<TreeNode>();
            parents.Enqueue(root);
            var level = new List<int>();
            while (parents.Count > 0)
            {
                var parent = parents.Dequeue();
                if (parent.left != null)
                {
                    children.Enqueue(parent.left);
                }

                if (parent.right != null)
                {
                    children.Enqueue(parent.right);
                }

                level.Add(parent.val);
                if (parents.Count == 0)
                {
                    parents = children;
                    children = new Queue<TreeNode>();
                    levels.Add(level);
                    level = new List<int>();
                }
            }

            return levels;
        }
    }
}