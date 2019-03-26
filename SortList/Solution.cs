namespace LeetCode.SortList
{
    public class Solution {
        public ListNode SortList(ListNode head) {
            int size;
            int mid;
            int leftIndex;
            int rightIndex;
            ListNode start;
            ListNode middle;
            ListNode runner;
            var sentinel = new ListNode(int.MinValue);
            sentinel.next = head;
            var length = GetLength(sentinel);
            for (size = 2; size < length * 2; size += size)
            {
                runner = sentinel;
                while (runner != null)
                {
                    start = runner.next;
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
                        runner.next = start;
                        while (leftIndex > 0)
                        {
                            runner = runner.next;
                            leftIndex--;
                        }

                        runner.next = middle == null ? null : middle;
                    }
                    else
                    {
                        runner.next = middle;
                        while (runner != null && rightIndex > 0)
                        {
                            runner = runner.next;
                            rightIndex--;
                        }
                    }
                }
            }

            return sentinel.next;
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