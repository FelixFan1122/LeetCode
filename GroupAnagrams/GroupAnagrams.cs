using System.Collections.Generic;
using System.Text;

namespace LeetCode.GroupAnagrams
{
    public class Solution
    {
        private const char Separator = ',';
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            if (strs == null)
            {
                return new List<IList<string>>();
            }

            var anagrams = new Dictionary<string, List<string>>();
            foreach (var str in strs)
            {
                var anagram = GenerateAnagram(str);
                if (!anagrams.ContainsKey(anagram))
                {
                    anagrams[anagram] = new List<string>();
                }

                anagrams[anagram].Add(str);
            }

            return ToList(anagrams);
        }

        private static string GenerateAnagram(string word)
        {
            var counts = new int[26];
            foreach (var character in word)
            {
                counts[character - 'a']++;
            }

            var anagram = new StringBuilder();
            for (var offset = 0; offset < counts.Length; offset++)
            {
                anagram.Append((char)('a' + offset));
                anagram.Append(counts[offset]);
                anagram.Append(Separator);
            }

            return anagram.Remove(anagram.Length - 1, 1).ToString();
        }

        private static IList<IList<TValue>> ToList<TKey, TValue>(Dictionary<TKey, List<TValue>> dict)
        {
            var list = new List<IList<TValue>>();
            foreach (var words in dict.Values)
            {
                list.Add(words);
            }

            return list;
        }
    }
}