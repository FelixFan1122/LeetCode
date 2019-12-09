using LeetCode;

namespace RemoveNthNodeFromEndOfList
{
    public class Solution
    {
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            var hare = head;
            while (n > 0 && hare != null)
            {
                hare = hare.next;
                n--;
            }

            if (n > 0)
            {
                return head;
            }

            var tortoise = head;
            ListNode previous = null;
            while (hare != null)
            {
                previous = tortoise;
                tortoise = tortoise.next;
                hare = hare.next;
            }

            if (previous == null)
            {
                return tortoise.next;
            }
            else
            {
                previous.next = tortoise.next;
                return head;
            }
        }
    }
}