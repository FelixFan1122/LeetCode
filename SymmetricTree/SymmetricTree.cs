namespace SymmetricTree
{
    public class Solution
    {
        public bool IsSymmetric(TreeNode root)
        {
            if (root == null)
            {
                return true;
            }

            return IsSymmetric(root.left, root.right);
        }

        private bool IsSymmetric(TreeNode tree1, TreeNode tree2)
        {
            if (tree1 == null)
            {
                return tree2 == null;
            }

            if (tree2 == null)
            {
                return false;
            }

            if (tree1.val != tree2.val)
            {
                return false;
            }

            return IsSymmetric(tree1.left, tree2.right) && IsSymmetric(tree1.right, tree2.left);
        }
    }
}