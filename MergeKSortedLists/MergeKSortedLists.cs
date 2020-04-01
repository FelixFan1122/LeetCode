namespace LeetCode.MergeKSortedLists
{
    public class Solution
    {
        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists == null || lists.Length == 0)
            {
                return null;
            }

            if (lists.Length == 1)
            {
                return lists[0];
            }

            var length = lists.Length;
            while (length != 1)
            {
                for (var i = 0; i < length; i += 2)
                {
                    lists[i / 2] = MergeTwoLists(lists[i], i == length - 1 ? null : lists[i + 1]);
                }

                length = length % 2 == 0 ? length / 2 : length / 2 + 1;
            }

            return lists[0];
        }

        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 == null)
            {
                return l2;
            }

            if (l2 == null)
            {
                return l1;
            }

            ListNode merged;
            if (l1.val < l2.val)
            {
                merged = l1;
                l1 = l1.next;
            }
            else
            {
                merged = l2;
                l2 = l2.next;
            }

            var current = merged;
            while (l1 != null && l2 != null)
            {
                if (l1.val < l2.val)
                {
                    current.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    current.next = l2;
                    l2 = l2.next;
                }

                current = current.next;
            }

            if (l1 == null)
            {
                current.next = l2;
            }
            else if (l2 == null)
            {
                current.next = l1;
            }

            return merged;
        }
    }
}