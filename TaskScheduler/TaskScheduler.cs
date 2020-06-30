using System;

namespace LeetCode.TaskScheduler
{
    public class Solution
    {
        public int LeastInterval(char[] tasks, int n)
        {
            if (tasks == null || tasks.Length == 0 || n < 0)
            {
                return 0;
            }

            var counter = new int[26];
            var maxFrequency = 0;
            var mostFrequentTaskCount = 0;
            foreach (var task in tasks)
            {
                counter[task - 'A']++;
                if (counter[task - 'A'] > maxFrequency)
                {
                    maxFrequency = counter[task - 'A'];
                    mostFrequentTaskCount = 1;
                }
                else if (counter[task - 'A'] == maxFrequency)
                {
                    mostFrequentTaskCount++;
                }
            }

            return tasks.Length + Math.Max((maxFrequency - 1) * (n + 1 - mostFrequentTaskCount) - (tasks.Length - maxFrequency * mostFrequentTaskCount), 0);
        }
    }
}