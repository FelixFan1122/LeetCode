using System;

namespace DiameterOfBinaryTree
{
    public class Solution
    {
        public int DiameterOfBinaryTree(TreeNode root)
        {
            return GetHeightAndDiameter(root).Item2;
        }

        private Tuple<int, int> GetHeightAndDiameter(TreeNode node)
        {
            if (node == null)
            {
                return new Tuple<int, int>(-1, 0);
            }

            var left = GetHeightAndDiameter(node.left);
            var right = GetHeightAndDiameter(node.right);
            var height = Math.Max(left.Item1, right.Item1) + 1;
            var diameter = Math.Max(Math.Max(left.Item2, right.Item2), left.Item1 + right.Item1 + 2);
            return new Tuple<int, int>(height, diameter);
        }
    }
}