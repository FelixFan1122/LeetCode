namespace LeetCode.ReverseLinkedListII
{
    public class Solution
    {
        public ListNode ReverseBetween(ListNode head, int m, int n)
        {
            if (m == n)
            {
                return head;
            }

            var sentinel = new ListNode(0);
            sentinel.next = head;

            head = sentinel;
            var count = 0;
            while (count < m - 1)
            {
                head = head.next;
                count++;
            }

            var tail = head.next;
            var previous = tail;
            var current = tail.next;
            count += 2;
            while (count <= n)
            {
                var next = current.next;
                current.next = previous;
                previous = current;
                current = next;
                count++;
            }

            head.next = previous;
            tail.next = current;

            return sentinel.next;
        }
    }
}