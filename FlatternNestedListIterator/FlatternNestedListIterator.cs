using System.Collections.Generic;

namespace LeetCode.FlatternNestedListIterator
{
    public class NestedIterator
    {
        private Stack<NestedInteger> flattened;
        public NestedIterator(IList<NestedInteger> nestedList)
        {
            flattened = new Stack<NestedInteger>();
            if (nestedList != null)
            {
                for (var i = nestedList.Count - 1; i >= 0; i--)
                {
                    flattened.Push(nestedList[i]);
                }
            }
        }

        public bool HasNext()
        {
            while (flattened.Count > 0)
            {
                var next = flattened.Peek();
                next = GetNextInteger(next);
                if (next != null)
                {
                    return true;
                }

                flattened.Pop();
            }

            return false;
        }

        public int Next()
        {
            while (!flattened.Peek().IsInteger())
            {
                var list = flattened.Pop().GetList();
                for (var i = list.Count - 1; i >= 0; i--)
                {
                    flattened.Push(list[i]);
                }
            }

            return flattened.Pop().GetInteger();
        }

        private NestedInteger GetNextInteger(NestedInteger nestedInteger)
        {
            if (nestedInteger.IsInteger())
            {
                return nestedInteger;
            }
            else
            {
                foreach (var nested in nestedInteger.GetList())
                {
                    var next = GetNextInteger(nested);
                    if (next != null)
                    {
                        return next;
                    }
                }
            }

            return null;
        }
    }

    // This is the interface that allows for creating nested lists.
    // You should not implement it, or speculate about its implementation
    public interface NestedInteger
    {

        // @return true if this NestedInteger holds a single integer, rather than a nested list.
        bool IsInteger();

        // @return the single integer that this NestedInteger holds, if it holds a single integer
        // Return null if this NestedInteger holds a nested list
        int GetInteger();

        // @return the nested list that this NestedInteger holds, if it holds a nested list
        // Return null if this NestedInteger holds a single integer
        IList<NestedInteger> GetList();
    }
}