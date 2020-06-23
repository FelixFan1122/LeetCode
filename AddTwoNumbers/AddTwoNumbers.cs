namespace LeetCode.AddTwoNumbers
{
    public class Solution
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var sum = new ListNode((l1.val + l2.val) % 10);
            var carryOver = (l1.val + l2.val < 10) ? 0 : 1;
            var current = sum;
            l1 = l1.next;
            l2 = l2.next;
            while (l1 != null || l2 != null)
            {
                var num1 = l1 == null ? 0 : l1.val;
                var num2 = l2 == null ? 0 : l2.val;
                var currentSum = num1 + num2 + carryOver;
                if (currentSum < 10)
                {
                    current.next = new ListNode(currentSum);
                    carryOver = 0;
                }
                else
                {
                    current.next = new ListNode(currentSum - 10);
                    carryOver = 1;
                }

                if (l1 != null)
                {
                    l1 = l1.next;
                }

                if (l2 != null)
                {
                    l2 = l2.next;
                }

                current = current.next;
            }

            if (carryOver > 0)
            {
                current.next = new ListNode(carryOver);
            }

            return sum;
        }
    }
}