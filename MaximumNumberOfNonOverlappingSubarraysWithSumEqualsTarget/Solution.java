package MaximumNumberOfNonOverlappingSubarraysWithSumEqualsTarget;

import java.util.HashSet;
import java.util.Set;

public class Solution {
    public int maxNonOverlapping(int[] nums, int target) {
        Set<Integer> prefixSums = new HashSet<>();
        prefixSums.add(0);
        int count = 0, sum = 0;
        for (int num : nums) {
            sum += num;
            if (prefixSums.contains(sum - target)) {
                count++;
                sum = 0;
                prefixSums.clear();
                prefixSums.add(0);
            } else {
                prefixSums.add(sum);
            }
        }
        return count;
    }
}
