namespace LeetCode.CountPrimes
{
    public class Solution
    {
        public int CountPrimes(int n)
        {
            var nonPrimes = new bool[n];
            var count = 0;
            for (var i = 2; i < n; i++)
            {
                if (nonPrimes[i] == false)
                {
                    count++;
                    for (var j = 2; j <= (n - 1) / i; j++)
                    {
                        nonPrimes[i * j] = true;
                    }
                }
            }

            return count;
        }
    }
}