namespace SumOfTwoIntegers
{
    public class Solution
    {
        public int GetSum(int a, int b)
        {
            while (b != 0)
            {
                var temp = a ^ b;
                b = (a & b) << 1;
                a = temp;
            }

            return a;
        }
    }
}