using System;

namespace HouseRobberIII
{
    public class Solution
    {
        public int Rob(TreeNode root)
        {
            var amount = RobOrSkip(root);
            return Math.Max(amount.Item1, amount.Item2);
        }

        private Tuple<int, int> RobOrSkip(TreeNode node)
        {
            if (node == null)
            {
                return new Tuple<int, int>(0, 0);
            }

            var left = RobOrSkip(node.left);
            var right = RobOrSkip(node.right);
            return new Tuple<int, int>(node.val + left.Item2 + right.Item2, Math.Max(left.Item1, left.Item2) + Math.Max(right.Item1, right.Item2));
        }
    }
}