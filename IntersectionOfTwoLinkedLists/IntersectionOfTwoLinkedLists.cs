namespace LeetCode.IntersectionOfTwoLinkedLists
{
    public class Solution
    {
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            if (headA == null || headB == null)
            {
                return null;
            }

            var runnerA = headA;
            var runnerB = headB;
            while (runnerA != runnerB)
            {
                runnerA = runnerA == null ? headB : runnerA.next;
                runnerB = runnerB == null ? headA : runnerB.next;
            }

            return runnerA;
        }
    }
}