using System;
using System.Collections.Generic;

namespace LeetCode.MaximumProductOfWordLengths
{
    public class Solution {
        public static Dictionary<char, int> Alphabet = new Dictionary<char, int>
        {
            { 'a', 1 }, { 'b', 1 << 1 }, { 'c', 1 << 2 }, { 'd', 1 << 3 }, { 'e', 1 << 4 }, { 'f', 1 << 5 }, { 'g', 1 << 6 },
            { 'h', 1 << 7 }, { 'i', 1 << 8 }, { 'j', 1 << 9 }, { 'k', 1 << 10 }, { 'l', 1 << 11 }, { 'm', 1 << 12 },
            { 'n', 1 << 13 },
            { 'o', 1 << 14 }, { 'p', 1 << 15 }, { 'q', 1 << 16 }, { 'r', 1 << 17 }, { 's', 1 << 18 }, { 't', 1 << 19 },
            { 'u', 1 << 20 }, { 'v', 1 << 21 }, { 'w', 1 << 22 }, { 'x', 1 << 23 }, { 'y', 1 << 24 }, { 'z', 1 << 25 }
        };

        public int MaxProduct(string[] words) {
            var wordLengths = BuildWordLengths(words);
            Array.Sort<WordLength>(wordLengths);
            var maxProduct = 0;
            for (var i = wordLengths.Length - 1; i >= 0; i--)
            {
                for (var j = i - 1; j >= 0 && wordLengths[i].Length * wordLengths[j].Length > maxProduct; j--)
                {
                    if ((wordLengths[i].AlphabetMap & wordLengths[j].AlphabetMap) == 0)
                    {
                        maxProduct = wordLengths[i].Length * wordLengths[j].Length;
                    }
                }
            }

            return maxProduct;
        }

        private static WordLength[] BuildWordLengths(string[] words)
        {
            var wordLengths = new WordLength[words.Length];
            for (var i = 0; i < words.Length; i++)
            {
                wordLengths[i] = new WordLength
                {
                    AlphabetMap = BuildAlphabetMap(words[i]),
                    Length = words[i].Length,
                    Word = words[i]
                };
            }

            return wordLengths;
        }

        private static int BuildAlphabetMap(string word)
        {
            var map = 0;
            foreach (var character in word)
            {
                map |= Alphabet[character];
            }

            return map;
        }

        private class WordLength : IComparable<WordLength>
        {
            internal int AlphabetMap { get; set; }
            internal int Length { get; set; }
            internal string Word { get; set; }

            public int CompareTo(WordLength other)
            {
                return this.Length.CompareTo(other.Length);
            }
        }
    }
}