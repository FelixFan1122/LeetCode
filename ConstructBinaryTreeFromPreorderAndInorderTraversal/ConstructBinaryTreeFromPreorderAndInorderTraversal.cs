namespace LeetCode.ConstructBinaryTreeFromPreorderAndInorderTraversal
{
    public class Solution
    {
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            if (preorder.Length == 0)
            {
                return null;
            }

            return BuildTree(preorder, inorder, 0, 0, preorder.Length);
        }

        private TreeNode BuildTree(int[] pre, int[] inorder, int i, int j, int length)
        {
            if (length == 0)
            {
                return null;
            }
            var node = new TreeNode(pre[i]);
            var index = j;
            while (inorder[index] != pre[i])
            {
                index++;
            }

            node.left = BuildTree(pre, inorder, i + 1, j, index - j);
            node.right = BuildTree(pre, inorder, i + 1 + index - j, index + 1, length - 1 - index + j);

            return node;
        }
    }
}