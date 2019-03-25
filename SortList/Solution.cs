namespace LeetCode.SortList
{
    public class Solution {
        public ListNode SortList(ListNode head) {
            var length = GetLength(head);
            int size;
            ListNode start = head;
            ListNode middle;
            ListNode runner = new ListNode(int.MaxValue);
            runner.next = head;
            int mid;
            int leftIndex;
            int rightIndex;
            for (size = 2; size < length; size += size)
            {
                while (runner != null)
                {
                    start = runner;
                    middle = start;
                    mid = size / 2;
                    while (middle != null && mid > 0)
                    {
                        middle = middle.next;
                        mid--;
                    }

                    if (middle == null)
                    {
                        break;
                    }
                    
                    leftIndex = size / 2;
                    rightIndex = size / 2;
                    while (middle != null && leftIndex > 0 && rightIndex > 0)
                    {
                        if (start.val < middle.val)
                        {
                            runner.next = start;
                            leftIndex--;
                            start = start.next;
                        }
                        else
                        {
                            runner.next = middle;
                            rightIndex--;
                            middle = middle.next;
                        }

                        runner = runner.next;
                    }

                    if (middle == null || leftIndex > 0)
                    {
                        runner = start;
                        while (leftIndex > 0)
                        {
                            runner = runner.next;
                            leftIndex--;
                        }
                    }
                    else
                    {
                        runner = middle;
                        while (runner != null && rightIndex > 0)
                        {
                            runner = runner.next;
                            rightIndex--;
                        }
                    }
                }
            }

            return head;
        }

        private static int GetLength(ListNode linkedList)
        {
            var length = 0;
            while (linkedList != null)
            {
                length++;
                linkedList = linkedList.next;
            }

            return length;
        }
    }
}