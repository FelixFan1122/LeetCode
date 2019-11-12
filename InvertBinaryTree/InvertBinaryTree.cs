namespace InvertBinaryTree
{
    public class Solution
    {
        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null)
            {
                return null;
            }

            root.right = InvertTree(root.right);
            root.left = InvertTree(root.left);
            var temp = root.left;
            root.left = root.right;
            root.right = temp;
            return root;
        }
    }
}