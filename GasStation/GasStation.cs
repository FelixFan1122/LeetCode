namespace LeetCode.GasStation
{
    public class Solution
    {
        public int CanCompleteCircuit(int[] gas, int[] cost)
        {
            var current = 0;
            var remain = 0;
            var start = 0;
            var total = 0;
            for (var i = 0; i < gas.Length; i++)
            {
                remain = gas[i] - cost[i];
                current += remain;
                total += remain;
                if (current < 0)
                {
                    current = 0;
                    start = i + 1;
                }
            }

            return total < 0 ? -1 : start;
        }
    }
}