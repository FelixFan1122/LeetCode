using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.ReformatDate
{
    public class Solution
    {
        private static Dictionary<string, string> months = new Dictionary<string, string> {
        { "Jan", "01" }, { "Feb", "02" }, { "Mar", "03" }, { "Apr", "04" }, { "May", "05" }, { "Jun", "06" },
        { "Jul", "07" }, { "Aug", "08" }, { "Sep", "09" }, { "Oct", "10" }, { "Nov", "11" }, { "Dec", "12" }
    };
        public string ReformatDate(string date)
        {
            var reformated = new StringBuilder(10);
            reformated.Append(date.Substring(date.Length - 4, 4));
            reformated.Append('-');
            reformated.Append(months[date.Substring(date.Length - 8, 3)]);
            reformated.Append('-');
            if (Char.IsDigit(date[1])) reformated.Append(date.Substring(0, 2));
            else
            {
                reformated.Append('0');
                reformated.Append(date[0]);
            }
            return reformated.ToString();
        }
    }
}