package NumberOfNodesInTheSubTreeWithTheSameLabel;

import java.util.ArrayList;

public class Solution {
    public int[] countSubTrees(int n, int[][] edges, String labels) {
        ArrayList<Integer>[] tree = (ArrayList<Integer>[]) new ArrayList[n];
        for (var i = 0; i < n; i++) tree[i] = new ArrayList<>();
        for (int[] edge : edges) {
            tree[edge[0]].add(edge[1]);
            tree[edge[1]].add(edge[0]);
        }
        int[] result = new int[n];
        dfs(0, -1, tree, labels, result);
        return result;
    }

    private int[] dfs(int current, int parent, ArrayList<Integer>[] tree, String labels, int[] result) {
        int[] count = new int[26];
        count[labels.charAt(current) - 'a']++;
        for (int i = 0; i < tree[current].size(); i++) {
            if (tree[current].get(i) == parent) continue;
            int[] childCount = dfs(tree[current].get(i), current, tree, labels, result);
            for (int j = 0; j < 26; j++) count[j] += childCount[j];
        }
        result[current] = count[labels.charAt(current) - 'a'];
        return count;
    }
}
