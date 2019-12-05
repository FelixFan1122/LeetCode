namespace PopulatingNextRightPointersInEachNode
{
    public class Solution
    {
        public Node Connect(Node root)
        {
            if (root == null)
            {
                return root;
            }

            var leftMost = root;
            while (leftMost.left != null)
            {
                var current = leftMost;
                while (current != null)
                {
                    current.left.next = current.right;
                    if (current.next != null)
                    {
                        current.right.next = current.next.left;
                    }

                    current = current.next;
                }

                leftMost = leftMost.left;
            }

            return root;
        }
    }
}