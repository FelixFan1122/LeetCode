namespace LeetCode.NumberOfSubstringsWithOnly1s
{
    public class Solution
    {
        public int NumSub(string s)
        {
            long run = 0, count = 0;
            for (var i = 0; i < s.Length; i++)
            {
                if (s[i] == '0')
                {
                    count = count + (run + 1) * run / 2;
                    run = 0;
                }
                else
                {
                    run++;
                }
            }
            count = count + (run + 1) * run / 2;
            return (int)(count % 1000000007);
        }
    }
}