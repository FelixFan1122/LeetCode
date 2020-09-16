package MinimumNumbersOfFunctionCallsToMakeTargetArray;

public class Solution {
    public int minOperations(int[] nums) {
        int ops = 0, max = 0;
        for (int num : nums) {
            int count = 0, bit = 0;
            while (num > 0) {
                if ((num & 1) == 1) {
                    count++;
                    max = Math.max(max, bit);
                }
                bit++;
                num >>= 1;
            }
            ops += count;
        }
        return ops + max;
    }
}
