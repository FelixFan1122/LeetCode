using System.Collections.Generic;
using System.Text;

namespace LeetCode.WordBreakII
{
    public class Solution
    {
        private const char Separator = ' ';
        public IList<string> WordBreak(string s, IList<string> wordDict)
        {
            var dictionary = new HashSet<string>(wordDict);
            var breaks = new List<int>[s.Length];
            for (var i = 0; i < breaks.Length; i++)
            {
                if (dictionary.Contains(s.Substring(0, i + 1)))
                {
                    if (breaks[i] == null)
                    {
                        breaks[i] = new List<int>();
                    }

                    breaks[i].Add(-1);
                }

                for (var j = 0; j < i; j++)
                {
                    if (breaks[j] != null && dictionary.Contains(s.Substring(j + 1, i - j)))
                    {
                        if (breaks[i] == null)
                        {
                            breaks[i] = new List<int>();
                        }

                        breaks[i].Add(j);
                    }
                }
            }

            var words = new List<string>();
            if (breaks[breaks.Length - 1] == null)
            {
                return words;
            }

            GenerateWords(new Stack<int>(), breaks.Length - 1, breaks, words, s.ToCharArray());

            return words;
        }

        private void GenerateWords(Stack<int> current, int index, List<int>[] breaks, IList<string> words, char[] s)
        {
            if (index == -1)
            {
                var clone = new Stack<int>(current.Count);
                var start = 0;
                var word = new StringBuilder();
                while (current.Count > 0)
                {
                    var separate = current.Pop();
                    if (separate != -1)
                    {
                        word.Append(s, start, separate - start + 1);
                        word.Append(Separator);
                        start = separate + 1;
                    }

                    clone.Push(separate);
                }

                word.Append(s, clone.Peek() + 1, s.Length - clone.Peek() - 1);
                words.Add(word.ToString());

                while (clone.Count > 0)
                {
                    current.Push(clone.Pop());
                }
            }
            else
            {
                foreach (var previous in breaks[index])
                {
                    current.Push(previous);
                    GenerateWords(current, previous, breaks, words, s);
                    current.Pop();
                }
            }
        }
    }
}