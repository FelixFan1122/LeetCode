package MinimumNumberOfRemovalsToMakeMountainArray;

public class Solution {
    public int minimumMountainRemovals(int[] nums) {
        int[] increasing = new int[nums.length];
        increasing[0] = 1;
        for (int i = 1; i < increasing.length; i++) {
            int maxval = 0;
            for (int j = 0; j < i; j++) {
                if (nums[i] > nums[j]) {
                    maxval = Math.max(maxval, increasing[j]);
                }
            }
            increasing[i] = maxval + 1;
        }
        int[] decreasing = new int[nums.length];
        decreasing[nums.length - 1] = 1;
        for (int i = nums.length - 2; i >= 0; i--) {
            int maxval = 0;
            for (int j = nums.length - 1; j > i; j--) {
                if (nums[i] > nums[j]) {
                    maxval = Math.max(maxval, decreasing[j]);
                }
            }
            decreasing[i] = maxval + 1;
        }
        int length = 0;
        for (int i = 0; i < nums.length; i++) {
            if (increasing[i] > 1 && decreasing[i] > 1 && increasing[i] + decreasing[i] - 1 > length) length = increasing[i] + decreasing[i] - 1;
        }
        return nums.length - length;
    }
}
