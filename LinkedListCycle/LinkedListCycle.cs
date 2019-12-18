using LeetCode;

namespace LinkedListCycle
{
    public class Solution
    {
        public bool HasCycle(ListNode head)
        {
            return DetectCycle(head) != null;
        }

        public ListNode DetectCycle(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return null;
            }

            var hare = head.next.next;
            var tortoise = head.next;
            while (hare != null && hare != tortoise)
            {
                if (hare.next == null)
                {
                    break;
                }

                hare = hare.next.next;
                tortoise = tortoise.next;
            }

            if (hare != tortoise)
            {
                return null;
            }

            hare = head;
            while (hare != tortoise)
            {
                hare = hare.next;
                tortoise = tortoise.next;
            }

            return hare;
        }
    }
}