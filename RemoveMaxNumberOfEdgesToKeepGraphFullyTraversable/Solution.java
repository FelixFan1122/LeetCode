package RemoveMaxNumberOfEdgesToKeepGraphFullyTraversable;

class Solution {
    public int maxNumEdgesToRemove(int n, int[][] edges) {
        UnionFind a = new UnionFind(n), b = new UnionFind(n);
        int count3 = 0;
        for (var edge : edges) {
            if (edge[0] == 3 && a.find(edge[1] - 1) != a.find(edge[2] - 1)) {
                count3++;
                a.union(edge[1] - 1, edge[2] - 1);
                b.union(edge[1] - 1, edge[2] - 1);
            }
        }
        if (count3 == n - 1) return edges.length - n + 1;
        int count1 = 0, count2 = 0;
        for (var edge : edges) {
            if (edge[0] == 1) {
                if (a.find(edge[1] - 1) != a.find(edge[2] - 1)) {
                    count1++;
                    a.union(edge[1] - 1, edge[2] - 1);
                }
            } else if (edge[0] == 2) {
                if (b.find(edge[1] - 1) != b.find(edge[2] - 1)) {
                    count2++;
                    b.union(edge[1] - 1, edge[2] - 1);
                }
            }
        }
        return count1 + count3 == n - 1 && count2 + count3 == n - 1 ? edges.length - count1 - count2 - count3 : -1;
    }
}
class UnionFind {
    int[] parents, sizes;
    UnionFind(int n) {
        parents = new int[n];
        sizes = new int[n];
        for (int i = 0; i < n; i++) {
            parents[i] = i;
            sizes[i] = 1;
        }
    }
    int find(int p) {
        if (parents[p] != p) parents[p] = find(parents[p]);
        return parents[p];
    }
    void union(int pp, int qq) {
        int p = find(pp), q = find(qq);
        if (p == q) return;
        if (sizes[p] < sizes[q]) {
            parents[p] = q;
            sizes[q] += sizes[p];
        } else {
            parents[q] = p;
            sizes[p] += sizes[q];
        }
    }
}
