package CountOfSmallerNumbersAfterSelf;

import java.util.ArrayList;
import java.util.List;

public class Solution {
    public List<Integer> countSmaller(int[] nums) {
        int[][] original = generateSecondaryKeys(nums);
        int[][] aux = new int[nums.length][];
        int[] count = new int[nums.length];
        for (int size = 1; size < nums.length; size += size) {
            for (int start = 0; start < nums.length - size; start += size + size) {
                int l = start, r = start + size, mid = start + size, end = Math.min(start + size + size, nums.length);
                System.arraycopy(original, start, aux, start, end - start);
                for (int i = start; i < end; i++) {
                    if (l >= mid) original[i] = aux[r++];
                    else if (r >= end) {
                        original[i] = aux[l++];
                        count[original[i][1]] += r - mid;
                    }
                    else if (aux[l][0] <= aux[r][0]) {
                        original[i] = aux[l++];
                        count[original[i][1]] += r - mid;
                    }
                    else original[i] = aux[r++];
                }
            }
        }
        ArrayList<Integer> result = new ArrayList<>(nums.length);
        for (int c : count) result.add(c);
        return result;
    }
    private int[][] generateSecondaryKeys(int[] nums) {
        int[][] generated = new int[nums.length][];
        for (int i = 0; i < nums.length; i++) generated[i] = new int[] { nums[i], i };
        return generated;
    }

    public static void main(String[] args) {
        new Solution().countSmaller(new int[] {5,2,6,1});
    }
}
