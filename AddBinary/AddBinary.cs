using System;

namespace LeetCode.AddBinary
{
    public class Solution
    {
        public string AddBinary(string a, string b)
        {
            var sum = new char[Math.Max(a.Length, b.Length)];
            var indexA = a.Length - 1;
            var indexB = b.Length - 1;
            var indexS = sum.Length - 1;
            var hasCarryOver = false;
            while (indexA >= 0 || indexB >= 0)
            {
                var charA = indexA >= 0 ? a[indexA] : '0';
                var charB = indexB >= 0 ? b[indexB] : '0';
                if (charA == '0' && charB == '0' && hasCarryOver)
                {
                    sum[indexS] = '1';
                    hasCarryOver = false;
                }
                else if ((charA == '0' && charB == '0' && !hasCarryOver) ||
                         (charA == '0' && charB == '1' && hasCarryOver) ||
                         (charA == '1' && charB == '0' && hasCarryOver))
                {
                    sum[indexS] = '0';
                }
                else if ((charA == '0' && charB == '1' && !hasCarryOver) ||
                         (charA == '1' && charB == '0' && !hasCarryOver) ||
                         (charA == '1' && charB == '1' && hasCarryOver))
                {
                    sum[indexS] = '1';
                }
                else if (charA == '1' && charB == '1' && !hasCarryOver)
                {
                    sum[indexS] = '0';
                    hasCarryOver = true;
                }

                indexA--;
                indexB--;
                indexS--;
            }

            var sumString = new string(sum);
            if (hasCarryOver)
            {
                sumString = "1" + sumString;
            }

            return sumString;
        }
    }
}