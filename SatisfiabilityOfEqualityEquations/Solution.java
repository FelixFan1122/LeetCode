package SatisfiabilityOfEqualityEquations;

class Solution {
    public boolean equationsPossible(String[] equations) {
        UnionFind uf = buildUf(equations);
        for (String equation : equations) if (equation.charAt(1) == '!' && uf.isConnected(equation.charAt(0) - 'a', equation.charAt(3) - 'a')) return false;
        return true;
    }
    UnionFind buildUf(String[] equations) {
        UnionFind uf = new UnionFind(26);
        for (String equation : equations) if (equation.charAt(1) == '=') uf.union(equation.charAt(0) - 'a', equation.charAt(3) - 'a');
        return uf;
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
    int find(int p) { return parent[p] = parent[p] == p ? p : find(parent[p]); }
    boolean isConnected(int p, int q) { return find(p) == find(q); }
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
