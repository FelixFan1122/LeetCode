using System;
using System.Collections.Generic;

namespace LeetCode.DesignBrowserHistory
{
    public class BrowserHistory
    {
        private int current;
        private List<string> history;
        private int sentinel;
        public BrowserHistory(string homepage)
        {
            history = new List<string>();
            history.Add(homepage);
            current = 0;
            sentinel = 0;
        }

        public void Visit(string url)
        {
            current++;
            sentinel = current;
            if (current < history.Count)
            {
                history[current] = url;
            }
            else
            {
                history.Add(url);
            }
        }

        public string Back(int steps)
        {
            current -= Math.Min(steps, current);
            return history[current];
        }

        public string Forward(int steps)
        {
            current += Math.Min(steps, sentinel - current);
            return history[current];
        }
    }
}