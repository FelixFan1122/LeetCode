using System.Collections.Generic;

namespace PathSum3
{
    public class Solution
    {
        public int PathSum(TreeNode root, int sum)
        {
            var ancestors = new Dictionary<int, int>();
            ancestors.Add(0, 1);
            return PathSum(root, sum, 0, ancestors);
        }

        private int PathSum(TreeNode node, int target, int current, Dictionary<int, int> ancestors)
        {
            if (node == null)
            {
                return 0;
            }

            current += node.val;
            var count = ancestors.ContainsKey(current - target) ? ancestors[current - target] : 0;
            if (!ancestors.ContainsKey(current))
            {
                ancestors.Add(current, 0);
            }

            ancestors[current]++;
            count += PathSum(node.left, target, current, ancestors);
            count += PathSum(node.right, target, current, ancestors);
            ancestors[current]--;
            return count;
        }
    }
}