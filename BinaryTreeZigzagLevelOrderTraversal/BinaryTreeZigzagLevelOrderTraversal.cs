using System.Collections.Generic;

namespace BinaryTreeZigzagLevelOrderTraversal
{
    public class Solution
    {
        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            if (root == null)
            {
                return new List<IList<int>>();
            }

            var traversal = new List<IList<int>>();
            var leftToRight = new Stack<TreeNode>();
            var rightToLeft = new Stack<TreeNode>();
            leftToRight.Push(root);
            while (leftToRight.Count > 0 || rightToLeft.Count > 0)
            {
                var level = new List<int>();
                if (leftToRight.Count > 0)
                {
                    while (leftToRight.Count > 0)
                    {
                        var node = leftToRight.Pop();
                        level.Add(node.val);
                        if (node.left != null)
                        {
                            rightToLeft.Push(node.left);
                        }

                        if (node.right != null)
                        {
                            rightToLeft.Push(node.right);
                        }
                    }
                }
                else
                {
                    while (rightToLeft.Count > 0)
                    {
                        var node = rightToLeft.Pop();
                        level.Add(node.val);
                        if (node.right != null)
                        {
                            leftToRight.Push(node.right);
                        }

                        if (node.left != null)
                        {
                            leftToRight.Push(node.left);
                        }
                    }
                }

                traversal.Add(level);
            }

            return traversal;
        }
    }
}