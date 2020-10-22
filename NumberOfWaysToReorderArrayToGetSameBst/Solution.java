package NumberOfWaysToReorderArrayToGetSameBst;

import java.util.Arrays;

class Solution {
    int MOD = 1000_000_007;
    int[][] comb;
    public int numOfWays(int[] nums) {
        generateCombinations(nums.length - 1);
        Node bst = constructBst(nums);
        return (int)((numOfWays(bst) - 1 + MOD) % MOD);
    }
    long numOfWays(Node node) {
        int leftSize = node.left == null ? 0 : node.left.size;
        int rightSize = node.right == null ? 0 : node.right.size;
        long leftWays = node.left == null ? 1 : numOfWays(node.left);
        long rightWays = node.right == null ? 1 : numOfWays(node.right);
        return comb[leftSize + rightSize][leftSize] * leftWays % MOD * rightWays % MOD;
    }
    void generateCombinations(int n) {
        comb = new int[n + 1][n + 1];
        comb[0][0] = 1;
        for (int i = 1; i <= n; i++) for (int j = 0; j <= i; j++) comb[i][j] = j == 0 ? 1 : (comb[i - 1][j - 1] + comb[i - 1][j]) % MOD;
    }
    Node constructBst(int[] nums) {
        UnionFind uf = new UnionFind(nums.length);
        Node[] nodes = new Node[nums.length + 1];
        for (int i = nums.length - 1; i >= 0; i--) {
            Node node = new Node(nums[i]);
            nodes[nums[i]] = node;
            if (nums[i] > 1 && nodes[nums[i] - 1] != null) {
                Node left = nodes[uf.getRoot(nums[i] - 1)];
                node.left = left;
                node.size += left.size;
                uf.union(nums[i], nums[i] - 1);
            }
            if (nums[i] < nums.length && nodes[nums[i] + 1] != null) {
                Node right = nodes[uf.getRoot(nums[i] + 1)];
                node.right = right;
                node.size += right.size;
                uf.union(nums[i], nums[i] + 1);
            }
        }
        return nodes[nums[0]];
    }
}
class Node {
    int val, size;
    Node left, right;
    Node(int val) {
        this.val = val;
        size = 1;
    }
}
class UnionFind {
    int[] parent, size, root;
    UnionFind(int n) {
        parent = new int[n + 1];
        size = new int[n + 1];
        root = new int[n + 1];
        Arrays.fill(size, 1);
        for (int i = 1; i <= n; i++) parent[i] = root[i] = i;
    }
    int getRoot(int p) { return root[find(p)]; }
    int find(int p) { return parent[p] = parent[p] == p ? p : find(parent[p]); }
    void union(int p, int q) {
        int pp = find(p), qq = find(q);
        if (size[pp] > size[qq]) {
            int temp = pp;
            pp = qq;
            qq = temp;
        }
        parent[pp] = qq;
        size[qq] += size[pp];
        root[qq] = p;
    }
}
