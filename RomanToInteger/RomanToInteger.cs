using System;

namespace LeetCode.RomanToInteger
{
    public class Solution
    {
        public int RomanToInt(string s)
        {
            if (s == null || s.Length == 0)
            {
                return 0;
            }

            var val = 0;
            for (var i = 0; i < s.Length; i++)
            {
                switch (s[i])
                {
                    case 'M':
                        val += 1000;
                        break;
                    case 'D':
                        val += 500;
                        break;
                    case 'C':
                        if ((i + 1 < s.Length) && (s[i + 1] == 'M' || s[i + 1] == 'D'))
                        {
                            val -= 100;
                        }
                        else
                        {
                            val += 100;
                        }

                        break;
                    case 'L':
                        val += 50;
                        break;
                    case 'X':
                        if ((i + 1 < s.Length) && (s[i + 1] == 'C' || s[i + 1] == 'L'))
                        {
                            val -= 10;
                        }
                        else
                        {
                            val += 10;
                        }

                        break;
                    case 'V':
                        val += 5;
                        break;
                    case 'I':
                        if ((i + 1 < s.Length) && (s[i + 1] == 'X' || s[i + 1] == 'V'))
                        {
                            val -= 1;
                        }
                        else
                        {
                            val += 1;
                        }

                        break;
                    default:
                        throw new ArgumentException("Non recognizable character.");
                }
            }

            return val;
        }
    }
}