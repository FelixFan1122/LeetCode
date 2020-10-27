package RedundantConnectionII;

class Solution {
    public int[] findRedundantDirectedConnection(int[][] edges) {
        int inDegreeTwo = -1, inDegreeTwoParent = -1;
        int[] parents = new int[edges.length + 1];
        for (int i = 0; i < edges.length && inDegreeTwo == -1; i++) {
            if (parents[edges[i][1]] > 0) {
                inDegreeTwo = edges[i][1];
                inDegreeTwoParent = edges[i][0];
            } else parents[edges[i][1]] = edges[i][0];
        }
        if (inDegreeTwo == -1) {
            UnionFind uf = new UnionFind(edges.length + 1);
            for (int[] edge : edges) {
                if (uf.isConnected(edge[0], edge[1])) return edge;
                uf.union(edge[0], edge[1]);
            }
            return new int[] { -1, -1 };
        } else {
            return isTree(edges, new int[] { inDegreeTwoParent, inDegreeTwo }) ? new int[] { inDegreeTwoParent, inDegreeTwo } : new int[] { parents[inDegreeTwo], inDegreeTwo };
        }
    }
    boolean isTree(int[][] edges, int[] removed) {
        UnionFind uf = new UnionFind(edges.length + 1);
        for (int[] edge : edges) {
            if (edge[0] == removed[0] && edge[1] == removed[1]) continue;
            if (uf.isConnected(edge[0], edge[1])) return false;
            uf.union(edge[0], edge[1]);
        }
        return true;
    }
}
class UnionFind {
    int[] parents, sizes;
    UnionFind(int n) {
        parents = new int[n];
        sizes = new int[n];
        for (int i = 0; i < n; i++) {
            parents[i] = i;
            sizes[i] = i;
        }
    }
    boolean isConnected(int p, int q) { return find(p) == find(q); }
    int find(int p) { return parents[p] = parents[p] == p ? p : find(parents[p]); }
    void union(int p, int q) {
        p = find(p);
        q = find(q);
        if (p == q) return;
        if (sizes[p] > sizes[q]) {
            sizes[p] += sizes[q];
            parents[q] = p;
        } else {
            sizes[q] += sizes[p];
            parents[p] = q;
        }
    }
}
