package ReversePairs;

public class Solution {
    public int reversePairs(int[] nums) {
        int count = 0;
        int[] aux = new int[nums.length];
        for (int size = 1; size < nums.length; size += size) {
            for (int start = 0; start < nums.length - size; start += size + size) {
                int l = start, r = start + size, mid = r, end = Math.min(start + size + size, nums.length);
                while (l < mid) {
                    while (r < end && nums[l] > nums[r] * 2L) r++;
                    count += r - mid;
                    l++;
                }
                l = start;
                r = mid;
                System.arraycopy(nums, start, aux, start, end - start);
                for (int i = start; i < end; i++) {
                    if (l >= mid) nums[i] = aux[r++];
                    else if (r >= end) nums[i] = aux[l++];
                    else if (aux[l] < aux[r]) nums[i] = aux[l++];
                    else nums[i] = aux[r++];
                }
            }
        }
        return count;
    }
}
