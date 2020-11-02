package ContainsDuplicateIII;

import java.util.HashMap;

public class Solution {
    public boolean containsNearbyAlmostDuplicate(int[] nums, int k, int t) {
        if (k == 0) return false;
        long size = t + 1;
        HashMap<Long, Integer> buckets = new HashMap<>();
        for (int i = 0; i < nums.length; i++) {
            long bucket = getBucket(nums[i], size);
            if (buckets.containsKey(bucket)) return true;
            if (buckets.containsKey(bucket - 1) && (long)nums[i] - buckets.get(bucket - 1) <= t) return true;
            if (buckets.containsKey(bucket + 1) && (long)buckets.get(bucket + 1) - nums[i] <= t) return true;
            if (i >= k) buckets.remove(getBucket(nums[i - k], size));
            buckets.put(bucket, nums[i]);
        }
        return false;
    }
    private long getBucket(long num, long size) {
        return num < 0 ? (num + 1) / size - 1 : num / size;
    }
}
