using System;
using System.Text;

namespace LeetCode.CountAndSay
{
    public class Solution
    {
        private const string Seed = "1";

        public string CountAndSay(int n)
        {
            if (n < 1)
            {
                return String.Empty;
            }

            var say = new StringBuilder(Seed);
            for (var i = 0; i < n - 1; i++)
            {
                var sb = new StringBuilder();
                char currentNumber = say[0];
                var count = 0;
                for (var j = 0; j < say.Length; j++)
                {
                    if (say[j] == currentNumber)
                    {
                        count++;
                    }
                    else
                    {
                        sb.Append(count);
                        sb.Append(currentNumber);
                        currentNumber = say[j];
                        count = 1;
                    }
                }

                sb.Append(count);
                sb.Append(currentNumber);

                say = sb;
            }

            return say.ToString();
        }
    }
}