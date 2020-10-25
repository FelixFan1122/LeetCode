package CouplesHoldingHands;

class Solution {
    public int minSwapsCouples(int[] row) {
        UnionFind uf = new UnionFind(row.length / 2);
        for (int i = 0; i < row.length; i += 2) uf.union(row[i] / 2, row[i + 1] / 2);
        return row.length / 2 - uf.count();
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
            if (size[pp] > size[qq]) {
                size[pp] += size[qq];
                parent[qq] = pp;
            } else {
                size[qq] += size[pp];
                parent[pp] = qq;
            }
        }
    }
}
