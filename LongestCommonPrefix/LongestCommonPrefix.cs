namespace LeetCode.LongestCommonPrefix
{
    public class Solution
    {
        public string LongestCommonPrefix(string[] strs)
        {
            if (strs == null || strs.Length == 0)
            {
                return string.Empty;
            }

            var i = 0;
            for (; i < strs[0].Length; i++)
            {
                for (var j = 0; j < strs.Length; j++)
                {
                    if (strs[j].Length <= i || strs[j][i] != strs[0][i])
                    {
                        return strs[0].Substring(0, i);
                    }
                }
            }

            return strs[0];
        }
    }
}