package ContainsDuplicateII;

import java.util.HashSet;

public class Solution {
    public boolean containsNearbyDuplicate(int[] nums, int k) {
        if (k <= 0) return false;
        HashSet<Integer> window = new HashSet<>();
        for (int i = 0; i < nums.length; i++) {
            if (window.contains(nums[i])) return true;
            if (window.size() == k) window.remove(nums[i - k]);
            window.add(nums[i]);
        }
        return false;
    }
}
