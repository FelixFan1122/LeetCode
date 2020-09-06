package MinimumSwapsToArrangeABinaryGrid;

public class Solution {
    public int minSwaps(int[][] grid) {
        int[] rows = new int[grid.length];
        for (int i = 0; i < grid.length; i++) {
            int j = grid[i].length - 1;
            while (j >= 0 && grid[i][j] == 0) j--;
            rows[i] = j;
        }
        int swaps = 0;
        for (int i = 0; i < grid.length; i++) {
            int candidate = i;
            while (candidate < grid.length && rows[candidate] > i) candidate++;
            if (candidate == grid.length) return -1;
            swaps += candidate - i;
            while (candidate > i) {
                int temp = rows[candidate - 1];
                rows[candidate - 1] = rows[candidate];
                rows[candidate] = temp;
                candidate--;
            }
        }
        return swaps;
    }
}
