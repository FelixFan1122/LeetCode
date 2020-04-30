using System.Collections.Generic;

namespace LeetCode.WordLadder
{
    public class Solution
    {
        private const char Wildcard = '.';

        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            var oneDistances = GenerateOneDistances(wordList);
            if (!wordList.Contains(endWord))
            {
                return 0;
            }

            var beginSet = new Dictionary<string, int>();
            var endSet = new Dictionary<string, int>();
            beginSet[beginWord] = 0;
            endSet[endWord] = 1;

            var beginLength = -1;
            var endLength = -1;
            while (beginSet.Count != beginLength && endSet.Count != endLength)
            {
                beginLength = beginSet.Count;
                endLength = endSet.Count;
                AddOneDistance(beginSet, oneDistances);
                foreach (var word in beginSet)
                {
                    if (endSet.ContainsKey(word.Key))
                    {
                        return beginSet[word.Key] + endSet[word.Key];
                    }
                }

                AddOneDistance(endSet, oneDistances);
                foreach (var word in endSet)
                {
                    if (beginSet.ContainsKey(word.Key))
                    {
                        return beginSet[word.Key] + endSet[word.Key];
                    }
                }
            }

            return 0;
        }

        private Dictionary<string, List<string>> GenerateOneDistances(IEnumerable<string> wordList)
        {
            var oneDistances = new Dictionary<string, List<string>>();
            foreach (var word in wordList)
            {
                var charArray = word.ToCharArray();
                for (var i = 0; i < charArray.Length; i++)
                {
                    var original = charArray[i];
                    charArray[i] = Wildcard;
                    var oneDistance = new string(charArray);
                    if (!oneDistances.ContainsKey(oneDistance))
                    {
                        oneDistances[oneDistance] = new List<string>();
                    }

                    oneDistances[oneDistance].Add(word);

                    charArray[i] = original;
                }
            }

            return oneDistances;
        }

        private void AddOneDistance(Dictionary<string, int> words, Dictionary<string, List<string>> oneDistances)
        {
            var oneAways = new Dictionary<string, int>();
            foreach (var word in words)
            {
                var charArray = word.Key.ToCharArray();
                for (var i = 0; i < charArray.Length; i++)
                {
                    var original = charArray[i];
                    charArray[i] = Wildcard;
                    var oneDistance = new string(charArray);
                    if (oneDistances.ContainsKey(oneDistance))
                    {
                        foreach (var oneDistanceWord in oneDistances[oneDistance])
                        {
                            oneAways[oneDistanceWord] = word.Value + 1;
                        }
                    }

                    charArray[i] = original;
                }
            }

            foreach (var oneAway in oneAways)
            {
                if (!words.ContainsKey(oneAway.Key))
                {
                    words[oneAway.Key] = oneAway.Value;
                }
            }
        }
    }
}