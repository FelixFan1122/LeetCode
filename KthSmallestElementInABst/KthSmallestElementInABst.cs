using System.Collections.Generic;

namespace LeetCode.KthSmallestElementInABst
{
    public class Solution
    {
        public int KthSmallest(TreeNode root, int k)
        {
            var path = new Stack<TreeNode>();

            while (true)
            {
                while (root != null)
                {
                    path.Push(root);
                    root = root.left;
                }

                if (k == 1)
                {
                    break;
                }

                k--;
                root = path.Pop().right;
            }

            return path.Pop().val;
        }
    }
}