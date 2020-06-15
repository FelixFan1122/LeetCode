using System.Collections.Generic;

namespace LeetCode.LetterCombinationsOfAPhoneNumber
{
    public class Solution
    {
        private static readonly Dictionary<char, char[]> digitToLetters = new Dictionary<char, char[]>()
    {
        { '2', new [] { 'a', 'b', 'c' } },
        { '3', new [] { 'd', 'e', 'f' } },
        { '4', new [] { 'g', 'h', 'i' } },
        { '5', new [] { 'j', 'k', 'l' } },
        { '6', new [] { 'm', 'n', 'o' } },
        { '7', new [] { 'p', 'q', 'r','s' } },
        { '8', new [] { 't', 'u', 'v' } },
        { '9', new [] { 'w', 'x', 'y', 'z' } }
    };

        public IList<string> LetterCombinations(string digits)
        {
            if (digits == null || digits.Length == 0)
            {
                return new string[0];
            }

            var combinations = new List<string>();
            LetterCombinations("", 0, digits, combinations);

            return combinations;
        }

        private void LetterCombinations(string current, int index, string digits, IList<string> combinations)
        {
            if (index == digits.Length)
            {
                combinations.Add(current);
            }
            else
            {
                foreach (var letter in digitToLetters[digits[index]])
                {
                    LetterCombinations(current + letter, index + 1, digits, combinations);
                }
            }
        }
    }
}