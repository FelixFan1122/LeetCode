package BricksFallingWhenHit.Solution;

class Solution {
    public int[] hitBricks(int[][] grid, int[][] hits) {
        boolean[] hit = new boolean[hits.length];
        for (int i = 0; i < hits.length; i++) {
            if (grid[hits[i][0]][hits[i][1]] == 1) {
                hit[i] = true;
                grid[hits[i][0]][hits[i][1]] = 0;
            }
        }
        int m = grid.length, n = grid[0].length;
        UnionFind uf = new UnionFind(m * n);
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (grid[i][j] == 0) continue;
                if (i == 0) uf.union(m * n, j);
                if (i > 0 && grid[i - 1][j] == 1) uf.union((i - 1) * n + j, i * n + j);
                if (j > 0 && grid[i][j - 1] == 1) uf.union(i * n + j - 1, i * n + j);
            }
        }
        int[] drops = new int[hits.length];
        int[][] directions = {{-1,0},{1,0},{0,-1},{0,1}};
        for (int i = hits.length - 1; i >= 0; i--) {
            if (!hit[i]) continue;
            int x = hits[i][0], y = hits[i][1], previous = uf.size(m * n);
            grid[x][y] = 1;
            if (x == 0) uf.union(m * n, y);
            for (int[] direction : directions) {
                int xx = x + direction[0], yy = y + direction[1];
                if (xx >= 0 && xx < m && yy >= 0 && yy < n && grid[xx][yy] == 1) uf.union(x * n + y, xx * n + yy);
            }
            drops[i] = Math.max(0, uf.size(m * n) - previous - 1);
        }
        return drops;
    }
}
class UnionFind {
    int[] parent, size;
    UnionFind(int n) {
        parent = new int[n + 1];
        size = new int[n + 1];
        for (int i = 0; i <= n; i++) {
            parent[i] = i;
            size[i] = 1;
        }
    }
    int find(int p) {
        if (parent[p] != p) parent[p] = find(parent[p]);
        return parent[p];
    }
    int size(int p) {
        return size[find(p)];
    }
    void union(int p, int q) {
        int pp = find(p), qq = find(q);
        if (pp == qq) return;
        if (size[pp] < size[qq]) {
            int temp = pp;
            pp = qq;
            qq = temp;
        }
        size[pp] += size[qq];
        parent[qq] = pp;
    }
}
