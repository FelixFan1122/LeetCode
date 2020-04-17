namespace LeetCode.StringToInteger
{
    public class Solution
    {
        public int MyAtoi(string str)
        {
            if (str == null || str == "")
            {
                return 0;
            }

            var index = 0;
            while (index < str.Length && str[index] == ' ')
            {
                index++;
            }

            if (index == str.Length)
            {
                return 0;
            }

            var sign = 1;
            if (str[index] == '+' || str[index] == '-')
            {
                if (str[index] == '-')
                {
                    sign = -1;
                }

                index++;
            }

            var converted = 0;
            while (index < str.Length && (str[index] - '0' >= 0 && str[index] - '0' <= 9))
            {
                var tail = str[index] - '0';
                if ((sign > 0 && converted > int.MaxValue / 10 || (converted == int.MaxValue / 10 && tail > 7)) ||
                   (sign < 0 && converted > int.MaxValue / 10 || (converted == int.MaxValue && tail > 8)))
                {
                    return sign > 0 ? int.MaxValue : int.MinValue;
                }

                converted = converted * 10 + tail;
                index++;
            }

            return sign * converted;
        }
    }
}