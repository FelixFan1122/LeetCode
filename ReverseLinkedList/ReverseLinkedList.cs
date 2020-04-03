namespace LeetCode.ReverseLinkedList
{
    public class Solution
    {
        public ListNode ReverseList(ListNode head)
        {
            if (head == null)
            {
                return head;
            }

            var next = head.next;
            head.next = null;
            while (next != null)
            {
                var temp = next.next;
                next.next = head;
                head = next;
                next = temp;
            }

            return head;
        }
    }
}