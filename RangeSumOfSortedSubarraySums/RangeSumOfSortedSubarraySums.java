package RangeSumOfSortedSubarraySums;

class Solution {
    public int rangeSum(int[] nums, int n, int left, int right) {
        int[] prefixSums = generatePrefixSums(nums);
        int[] prefixSumsOfPrefixSums = generatePrefixSums(prefixSums);
        return (int)((rangeSum(prefixSums, right, prefixSumsOfPrefixSums) - rangeSum(prefixSums, left - 1, prefixSumsOfPrefixSums)) % 1000000007);
    }

    private long rangeSum(int[] prefixSums, int k, int[] prefixSumsOfPrefixSums) {
        if (k == 0) return 0;
        int kth = kthSmallest(prefixSums, k);
        int smallerThanKthCount = 0;
        long smallerThanKthSum = 0;
        for (int i = 0, j = 0; i < prefixSums.length; i++) {
            while (j < prefixSums.length && prefixSums[j] - (i == 0 ? 0 : prefixSums[i - 1]) < kth) j++;
            smallerThanKthSum += j == 0 ? 0 : (prefixSumsOfPrefixSums[j - 1] - (i == 0 ? 0 : prefixSumsOfPrefixSums[i - 1] + (j - i) * prefixSums[i - 1]));
            smallerThanKthCount += j - i;
        }
        return smallerThanKthSum += (k - smallerThanKthCount) * kth;
    }

    private int kthSmallest(int[] prefixSums, int k) {
        int low = 1, high = prefixSums[prefixSums.length - 1];
        while (low < high) {
            int mid = low + (high - low) / 2;
            int count = 0;
            for (int i = 0, j = 0; i < prefixSums.length; i++) {
                while (j < prefixSums.length && prefixSums[j] - (i == 0 ? 0 : prefixSums[i - 1]) <= mid) j++;
                count += j - i;
            }
            if (count < k) low = mid + 1;
            else high = mid;
        }
        return low;
    }

    private int[] generatePrefixSums(int[] nums) {
        int[] prefixSums = new int[nums.length];
        prefixSums[0] = nums[0];
        for (int i = 1; i < nums.length; i++) {
            prefixSums[i] = prefixSums[i - 1] + nums[i];
        }
        return prefixSums;
    }

    public static void main(String[] args) {
        System.out.println(new Solution().rangeSum(new int[]{7,5,8,5,6,4,3,3}, 8, 2, 6));
    }
}