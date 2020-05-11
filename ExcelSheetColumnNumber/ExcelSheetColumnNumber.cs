namespace LeetCode.ExcelSheetColumnNumber
{
    public class Solution
    {
        public int TitleToNumber(string s)
        {
            if (s == null)
            {
                return 0;
            }

            var sum = 0;
            var radix = 1;
            for (var i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] < 'A' || s[i] > 'Z')
                {
                    return -1;
                }

                sum += (s[i] - 'A' + 1) * radix;
                radix *= 26;
            }

            return sum;
        }
    }
}