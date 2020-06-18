namespace LeetCode.IntegerToRoman
{
    public class Solution
    {
        private static readonly string[] thousands = new string[] { System.String.Empty, "M", "MM", "MMM" };
        private static readonly string[] hundreds = new string[] { System.String.Empty, "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
        private static readonly string[] tens = new string[] { System.String.Empty, "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
        private static readonly string[] ones = new string[] { System.String.Empty, "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };

        public string IntToRoman(int num)
        {
            if (num <= 0 || num >= 4000)
            {
                return System.String.Empty;
            }

            return thousands[num / 1000] + hundreds[(num - num / 1000 * 1000) / 100] + tens[(num - num / 100 * 100) / 10] + ones[(num - num / 10 * 10)];
        }
    }
}