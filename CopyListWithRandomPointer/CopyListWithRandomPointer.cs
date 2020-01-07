namespace LeetCode.CopyListWithRandomPointer
{
    public class Solution
    {
        public Node CopyRandomList(Node head)
        {
            if (head == null)
            {
                return null;
            }

            var current = head;
            while (current != null)
            {
                current.next = new Node(current.val, current.next, current.random);
                current = current.next.next;
            }

            current = head;
            while (current != null)
            {
                current.next.random = current.next.random == null ? null : current.next.random.next;
                current = current.next.next;
            }

            var copyHead = head.next;
            current = head;
            while (current.next.next != null)
            {
                var copy = current.next;
                current.next = copy.next;
                copy.next = copy.next.next;
                current = current.next;
            }

            current.next = null;

            return copyHead;
        }
    }

    public class Node
        {
            public int val;
            public Node next;
            public Node random;

            public Node() { }
            public Node(int _val, Node _next, Node _random)
            {
                val = _val;
                next = _next;
                random = _random;
            }
        }
}