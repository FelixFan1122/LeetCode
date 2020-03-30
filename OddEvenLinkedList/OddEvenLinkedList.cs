namespace LeetCode.OddEvenLinkedList
{
    public class Solution
    {
        public ListNode OddEvenList(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }

            var oddHead = head;
            var evenHead = head.next;
            var oddRunner = oddHead;
            var evenRunner = evenHead;
            head = head.next.next;
            while (head != null)
            {
                oddRunner.next = head;
                oddRunner = oddRunner.next;
                head = head.next;
                if (head == null)
                {
                    break;
                }

                evenRunner.next = head;
                evenRunner = evenRunner.next;
                head = head.next;
            }

            evenRunner.next = null;
            oddRunner.next = evenHead;
            return oddHead;
        }
    }
}