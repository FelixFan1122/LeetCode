namespace LeetCode.LowestCommonAncestorOfABinaryTree
{
    public class Solution
    {
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null || p == null || q == null)
            {
                return null;
            }

            if (root == p || root == q)
            {
                return root;
            }

            var left = LowestCommonAncestor(root.left, p, q);
            var right = LowestCommonAncestor(root.right, p, q);
            if (left == null)
            {
                return right;
            }

            if (right == null)
            {
                return left;
            }

            return root;
        }
    }
}