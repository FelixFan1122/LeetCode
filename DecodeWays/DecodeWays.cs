namespace LeetCode.DecodeWays
{
    public class Solution
    {
        public int NumDecodings(string s)
        {
            if (s == null || s.Length == 0 || s[0] == '0')
            {
                return 0;
            }

            var previousTwo = 1;
            var previous = 1;
            var current = 1;
            for (var i = 1; i < s.Length; i++)
            {
                if (s[i] == '0')
                {
                    if (s[i - 1] != '1' && s[i - 1] != '2')
                    {
                        return 0;
                    }

                    current = previousTwo;
                }
                else if (s[i - 1] == '0')
                {
                    current = previous;
                }
                else
                {
                    current = int.Parse(s.Substring(i - 1, 2)) > 26 ? previous : previous + previousTwo;
                }

                previousTwo = previous;
                previous = current;
            }

            return current;
        }
    }
}