namespace LeetCode.PalindromeLinkedList
{
    public class Solution
    {
        public bool IsPalindrome(ListNode head)
        {
            if (head == null)
            {
                return true;
            }

            var length = GetLength(head);
            head = ReverseBetween(head, 1, length / 2);

            var hare = head;
            for (var i = 0; i < (length + 1) / 2; i++)
            {
                hare = hare.next;
            }

            while (hare != null)
            {
                if (head.val != hare.val)
                {
                    return false;
                }

                head = head.next;
                hare = hare.next;
            }

            return true;
        }

        private int GetLength(ListNode head)
        {
            var length = 0;
            while (head != null)
            {
                length++;
                head = head.next;
            }

            return length;
        }

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