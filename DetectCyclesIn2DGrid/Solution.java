package DetectCyclesIn2DGrid;

import java.util.Arrays;

class Solution {
    public boolean containsCycle(char[][] grid) {
        UnionFind uf = new UnionFind(grid.length * grid[0].length);
        for (int i = 0; i < grid.length; i++) {
            for (int j = 0; j < grid[0].length; j++) {
                if (i > 0 && grid[i - 1][j] == grid[i][j] && j > 0 && grid[i][j - 1] == grid[i][j] && uf.isConnected((i - 1) * grid[0].length + j, i * grid[0].length + j - 1)) return true;
                if (i > 0 && grid[i - 1][j] == grid[i][j]) uf.union((i - 1) * grid[0].length + j, i * grid[0].length + j);
                if (j > 0 && grid[i][j - 1] == grid[i][j]) uf.union(i * grid[0].length + j - 1, i * grid[0].length + j);
            }
        }
        return false;
    }
}
class UnionFind {
    int[] ids;
    int[] sizes;
    UnionFind(int capacity) {
        ids = new int[capacity];
        for (int i = 0; i < ids.length; i++) ids[i] = i;
        sizes = new int[capacity];
        Arrays.fill(sizes, 1);
    }
    void union(int i, int j) {
        int ii = find(i), jj = find(j);
        if (ii != jj) {
            if (sizes[ii] < sizes[jj]) {
                ids[ii] = jj;
                sizes[jj] += sizes[ii];
            } else {
                ids[jj] = ii;
                sizes[ii] += sizes[jj];
            }
        }
    }
    int find(int i) {
        if (ids[i] != i) ids[i] = find(ids[i]);
        return ids[i];
    }
    boolean isConnected(int i, int j) {
        return find(i) == find(j);
    }
}
