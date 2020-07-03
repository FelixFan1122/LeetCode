namespace LeetCode.EditDistance
{
    public class Solution
    {
        public int MinDistance(string word1, string word2)
        {
            var distance = new LevenshteinDistance(word1, word2);
            return distance.GetEditDistance();
        }
    }
}