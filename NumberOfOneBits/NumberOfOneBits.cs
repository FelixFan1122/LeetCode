namespace NumberOfOneBits
{
    public class Solution
    {
        public int HammingWeight(uint n)
        {
            var weight = 0;
            while (n > 0)
            {
                n &= n - 1;
                weight++;
            }

            return weight;
        }
    }
}