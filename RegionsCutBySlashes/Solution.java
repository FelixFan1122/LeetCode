package RegionsCutBySlashes;

class Solution {
    public int regionsBySlashes(String[] grid) {
        int n = grid.length;
        UnionFind uf = new UnionFind(n * n * 4);
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                int offset = (i * n + j) * 4;
                switch (grid[i].charAt(j)) {
                    case '/':
                        uf.union(offset, offset + 3);
                        uf.union(offset + 1, offset + 2);
                        break;
                    case '\\':
                        uf.union(offset, offset + 1);
                        uf.union(offset + 2, offset + 3);
                        break;
                    default:
                        uf.union(offset, offset + 1);
                        uf.union(offset, offset + 2);
                        uf.union(offset, offset + 3);
                }
                if (i > 0) uf.union(offset, 2 + ((i - 1) * n + j) * 4);
                if (j > 0) uf.union(offset + 3, 1 + (i * n + j - 1) * 4);
            }
        }
        return uf.count();
    }
}
class UnionFind {
    int count;
    int[] parent, size;
    UnionFind(int n) {
        count = n;
        parent = new int[n];
        size = new int[n];
        for (int i = 0; i < n; i++) {
            parent[i] = i;
            size[i] = 1;
        }
    }
    int count() { return count; }
    int find(int p) { return parent[p] = parent[p] == p ? p : find(parent[p]); }
    void union(int p, int q) {
        int pp = find(p), qq = find(q);
        if (pp != qq) {
            count--;
            if (size[pp] < size[qq]) {
                size[qq] += size[pp];
                parent[pp] = qq;
            } else {
                size[pp] += size[qq];
                parent[qq] = pp;
            }
        }
    }
}
