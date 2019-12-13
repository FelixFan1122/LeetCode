using System;
using System.Collections.Generic;

namespace MinStack
{
    public class MinStack
    {
        private Stack<Tuple<int, int>> stack = new Stack<Tuple<int, int>>();
        /** initialize your data structure here. */
        public MinStack()
        {

        }

        public void Push(int x)
        {
            stack.Push(new Tuple<int, int>(x, stack.Count == 0 || stack.Peek().Item2 > x ? x : stack.Peek().Item2));
        }

        public void Pop()
        {
            stack.Pop();
        }

        public int Top()
        {
            return stack.Peek().Item1;
        }

        public int GetMin()
        {
            return stack.Peek().Item2;
        }
    }
}