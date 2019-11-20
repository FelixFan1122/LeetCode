namespace MergeTwoBinaryTrees
{
    public class Solution
    {
        public TreeNode MergeTrees(TreeNode t1, TreeNode t2)
        {
            if (t1 == null)
            {
                return Clone(t2);
            }

            if (t2 == null)
            {
                return Clone(t1);
            }

            var root = new TreeNode(t1.val + t2.val);
            root.left = MergeTrees(t1.left, t2.left);
            root.right = MergeTrees(t1.right, t2.right);
            return root;
        }

        private TreeNode Clone(TreeNode node)
        {
            if (node == null)
            {
                return null;
            }

            var clone = new TreeNode(node.val);
            clone.left = Clone(node.left);
            clone.right = Clone(node.right);
            return clone;
        }
    }
}