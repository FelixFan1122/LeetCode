using System.Collections.Generic;

namespace FindAllAnagramsInAString
{
    public class Solution {
        public IList<int> FindAnagrams(string s, string p) {
            var anagrams = new List<int>();
            if (s == null || p == null)
            {
                return anagrams;
            }        
            
            var target = new Dictionary<char, int>();
            foreach (var character in p)
            {
                if (!target.ContainsKey(character))
                {
                    target.Add(character, 0);
                }
                
                target[character]++;
            }
            
            var candidate = new Dictionary<char, int>();
            var left = 0;
            var right = 0;
            while (right < s.Length)
            {
                if (target.ContainsKey(s[right]))
                {
                    if (!candidate.ContainsKey(s[right]))
                    {
                        candidate.Add(s[right], 0);
                    }
                    
                    candidate[s[right]]++;
                    if (candidate[s[right]] > target[s[right]])
                    {
                        while (left <= right && candidate[s[right]] > target[s[right]])
                        {
                            candidate[s[left]]--;
                            left++;
                        }
                    }
                    
                    if (right - left + 1 == p.Length)
                    {
                        anagrams.Add(left);
                        candidate[s[left]]--;
                        left++;
                    }
                    
                    right++;
                }
                else
                {
                    right++;
                    left = right;
                    candidate.Clear();
                }
            }
            
            return anagrams;
        }
    }                  
}