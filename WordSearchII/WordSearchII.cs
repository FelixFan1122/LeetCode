using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.WordSearchII
{
    public class Solution
    {
        private static readonly int[][] Directions = new[]
        {
            new[] { 1, 0 },
            new[] { -1, 0 },
            new[] { 0, 1 },
            new[] { 0, -1 }
        };

        public IList<string> FindWords(char[][] board, string[] words)
        {
            if (board == null || board.Length == 0 || board[0].Length == 0 || words == null || words.Length == 0)
            {
                return new List<string>();
            }

            var dictionary = new Trie<bool>();
            foreach (var word in words)
            {
                dictionary.Put(word, true);
            }

            var found = new HashSet<string>();
            for (var i = 0; i < board.Length; i++)
            {
                for (var j = 0; j < board[0].Length; j++)
                {
                    var visited = new HashSet<Tuple<int, int>>();
                    visited.Add(new Tuple<int, int>(i, j));
                    FindWords(board, i, j, dictionary, found, new string(new[] { board[i][j] }), visited);
                }
            }

            return found.ToList();
        }

        private void FindWords(char[][] board, int i, int j, Trie<bool> dictionary, HashSet<string> found, string current, HashSet<Tuple<int, int>> visited)
        {
            if (!dictionary.GetKeysOfPrefix(current).Any())
            {
                return;
            }

            if (dictionary.Get(current) == true)
            {
                found.Add(current);
            }

            foreach (var direction in Directions)
            {
                var ii = i + direction[0];
                var jj = j + direction[1];
                var coordinate = new Tuple<int, int>(ii, jj);
                if (ii >= 0 && ii < board.Length && jj >= 0 && jj < board[0].Length && !visited.Contains(coordinate))
                {
                    visited.Add(coordinate);
                    FindWords(board, ii, jj, dictionary, found, current + board[ii][jj], visited);
                    visited.Remove(coordinate);
                }
            }
        }
    }
}