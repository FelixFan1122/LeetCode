package RedundantConnection;

class Solution {
    public int[] findRedundantConnection(int[][] edges) {
        UnionFind uf = new UnionFind(edges.length + 1);
        for (int[] edge : edges) {
            if (uf.isConnected(edge[0], edge[1])) return edge;
            uf.union(edge[0], edge[1]);
        }
        return new int[] { -1, -1 };
    }
}
class UnionFind {
    int[] parent, size;
    UnionFind(int n) {
        parent = new int[n];
        size = new int[n];
        for (int i = 0; i < n; i++) {
            parent[i] = i;
            size[i] = 1;
        }
    }
    boolean isConnected(int p, int q) { return find(p) == find(q); }
    int find(int p) { return parent[p] = parent[p] == p ? p : find(parent[p]); }
    void union(int p, int q) {
        int pp = find(p), qq = find(q);
        if (pp != qq) {
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
