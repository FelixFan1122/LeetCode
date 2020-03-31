namespace LeetCode.DeleteNodeInALinkedList
{
    public class Solution
    {
        public void DeleteNode(ListNode node)
        {
            if (node == null)
            {
                return;
            }

            var previous = node;
            while (node.next != null)
            {
                node.val = node.next.val;
                previous = node;
                node = node.next;
            }

            previous.next = null;
        }
    }
}