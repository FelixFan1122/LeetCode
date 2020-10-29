package SwimInRisingWater;

import java.util.PriorityQueue;

public class Solution {
    private static final int[][] DIRECTIONS = {{ 0, 1}, { 0, -1 }, { 1, 0 }, { -1, 0 }};
    public int swimInWater(int[][] grid) {
        int max = grid[grid.length - 1][grid.length - 1];
        int[][] indices = new int[grid.length * grid.length][];
        for (int i = 0; i < grid.length; i++) for (int j = 0; j < grid.length; j++) indices[grid[i][j]] = new int[] { i, j };
        PriorityQueue<Integer> pq = new PriorityQueue<>();
        pq.offer(grid[0][0]);
        while (true) {
            int min = pq.poll();
            max = Math.max(max, min);
            int[] position = indices[min];
            grid[position[0]][position[1]] = grid.length * grid.length;
            for (int[] direction : DIRECTIONS) {
                int x = position[0] + direction[0], y = position[1] + direction[1];
                if (x >= 0 && x < grid.length && y >= 0 && y < grid.length) {
                    if (x == grid.length - 1 && y == grid.length - 1) return max;
                    pq.offer(grid[x][y]);
                }
            }
        }
    }
}
