using System.Linq;

namespace LeetCode.WordSearch
{
    public class Solution
    {
        public bool Exist(char[][] board, string word) => new WordSearchII.Solution().FindWords(board, new[] { word }).Any();
    }
}