namespace FlatternBinaryTreeToLinkedList
{
    public class Solution
    {
        public void Flatten(TreeNode root)
        {
            while (root != null)
            {
                if (root.left != null)
                {
                    var rightMost = root.left;
                    while (rightMost.right != null)
                    {
                        rightMost = rightMost.right;
                    }

                    rightMost.right = root.right;
                    root.right = root.left;
                    root.left = null;
                }

                root = root.right;
            }
        }
    }
}