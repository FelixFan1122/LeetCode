using System;
using System.Collections.Generic;

namespace PalindromePartitioning
{
    public class Solution
    {
        public IList<IList<string>> Partition(string s)
        {
            var partitions = new List<IList<string>>();
            if (s == null || s.Length == 0)
            {
                return partitions;
            }

            Partition(s, partitions, 0, new List<string>(), new Dictionary<Tuple<int, int>, bool>());

            return partitions;
        }

        private void Partition(string s, IList<IList<string>> partitions, int current, IList<string> previous, Dictionary<Tuple<int, int>, bool> palindromes)
        {
            if (current >= s.Length)
            {
                partitions.Add(new List<string>(previous));
            }
            else
            {
                for (var i = current; i < s.Length; i++)
                {
                    if (IsPalindrome(s, current, i, palindromes))
                    {
                        previous.Add(s.Substring(current, i - current + 1));
                        Partition(s, partitions, i + 1, previous, palindromes);
                        previous.RemoveAt(previous.Count - 1);
                    }
                }
            }
        }

        private bool IsPalindrome(string s, int start, int end, Dictionary<Tuple<int, int>, bool> palindromes)
        {
            var key = new Tuple<int, int>(start, end);
            if (!palindromes.ContainsKey(key))
            {
                var isPalindrome = true;
                while (isPalindrome && start < end)
                {
                    isPalindrome = s[start++] == s[end--];
                }

                palindromes[key] = isPalindrome;
            }

            return palindromes[key];
        }
    }
}