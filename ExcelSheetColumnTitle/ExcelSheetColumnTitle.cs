using System.Text;

namespace LeetCode.ExcelSheetColumnTitle
{
    public class Solution
    {
        public string ConvertToTitle(int n)
        {
            var title = new StringBuilder();
            while (n > 0)
            {
                n--;
                title.Insert(0, (char)('A' + n % 26));
                n /= 26;
            }

            return title.ToString();
        }
    }
}