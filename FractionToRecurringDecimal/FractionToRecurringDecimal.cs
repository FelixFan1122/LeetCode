using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.FractionToRecurringDecimal
{
    public class Solution
    {
        public string FractionToDecimal(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                return string.Empty;
            }

            if (numerator == 0)
            {
                return "0";
            }

            var deci = new StringBuilder();
            if ((numerator ^ denominator) < 0)
            {
                deci.Append('-');
            }

            var numeratorLong = (long)numerator;
            var denominatorLong = (long)denominator;
            numeratorLong = Math.Abs(numeratorLong);
            denominatorLong = Math.Abs(denominatorLong);
            var quotient = numeratorLong / denominatorLong;
            var remainder = numeratorLong % denominatorLong;
            deci.Append(quotient);
            if (remainder == 0)
            {
                return deci.ToString();
            }

            deci.Append('.');
            var recurring = new Dictionary<long, int>();
            while (remainder != 0)
            {
                if (recurring.ContainsKey(remainder))
                {
                    deci.Insert(recurring[remainder], '(');
                    deci.Append(')');
                    return deci.ToString();
                }

                recurring[remainder] = deci.Length;
                remainder *= 10;
                deci.Append(remainder / denominatorLong);
                remainder = remainder % denominatorLong;
            }

            return deci.ToString();
        }
    }
}