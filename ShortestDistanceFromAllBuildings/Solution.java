package ShortestDistanceFromAllBuildings;

import java.util.HashSet;
import java.util.LinkedList;

public class Solution {

    private static final int[][] DIRECTIONS = new int[][] {
            { -1, 0 },
            { 0, 1 },
            { 1, 0 },
            { 0, -1 }
    };

    public int shortestDistance(int[][] grid) {
        int count = 0;
        int[][] reached = new int[grid.length][grid[0].length];
        for (int i = 0; i < grid.length; i++) {
            for (int j = 0; j < grid[0].length; j++) {
                if (grid[i][j] == 1) {
                    count++;
                    bfs(grid, reached, i, j);
                }
            }
        }
        int min = Integer.MIN_VALUE;
        for (int i = 0; i < grid.length; i++) {
            for (int j = 0; j < grid[0].length; j++) {
                if (grid[i][j] < 0 && reached[i][j] == count) min = Math.max(min, grid[i][j]);
            }
        }
        return min == Integer.MIN_VALUE ? -1 : -min;
    }

    private static void bfs(int[][] grid, int[][] reached, int i, int j) {
        var q = new LinkedList<int[]>();
        var visited = new HashSet<Integer>();
        q.offer(new int[] { i, j });
        visited.add(i * grid[0].length + j);
        int distance = 0;
        while (!q.isEmpty()) {
            distance++;
            int size = q.size();
            for (int k = 0; k < size; k++) {
                var cell = q.poll();
                for (var direction : DIRECTIONS) {
                    int ii = cell[0] + direction[0], jj = cell[1] + direction[1];
                    if (ii >= 0 && ii < grid.length && jj >= 0 && jj < grid[0].length && grid[ii][jj] <= 0 && !visited.contains(ii * grid[0].length + jj)) {
                        reached[ii][jj]++;
                        grid[ii][jj] -= distance;
                        q.offer(new int[] { ii, jj });
                        visited.add(ii * grid[0].length + jj);
                    }
                }
            }
        }
    }
}
