using System.Collections.Generic;

namespace LeetCode.SubstringWithConcatenationOfAllWords
{
    public class Solution
    {
        public IList<int> FindSubstring(string s, string[] words)
        {
            var indices = new List<int>();
            if (s == null || words == null || words.Length == 0)
            {
                return indices;
            }

            var wordCount = words.Length;
            var wordLength = words[0].Length;
            var dictionary = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (!dictionary.ContainsKey(word))
                {
                    dictionary[word] = 0;
                }

                dictionary[word] += 1;
            }

            for (var i = 0; i < wordLength; i++)
            {
                var left = i;
                var right = i;
                var count = 0;
                var counter = new Dictionary<string, int>();
                while (right <= s.Length - wordLength)
                {
                    var candidate = s.Substring(right, wordLength);
                    if (!dictionary.ContainsKey(candidate))
                    {
                        left = right + wordLength;
                        right = left;
                        count = 0;
                        counter.Clear();
                    }
                    else
                    {
                        if (!counter.ContainsKey(candidate))
                        {
                            counter[candidate] = 0;
                        }

                        counter[candidate] += 1;
                        count++;
                        if (counter[candidate] > dictionary[candidate])
                        {
                            while (counter[candidate] > dictionary[candidate])
                            {
                                var toRemove = s.Substring(left, wordLength);
                                counter[toRemove] -= 1;
                                count--;
                                left += wordLength;
                            }
                        }

                        if (count == wordCount)
                        {
                            indices.Add(left);
                        }

                        right += wordLength;
                    }
                }
            }

            return indices;
        }
    }
}