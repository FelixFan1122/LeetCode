package IsGraphBipartite;

public class Solution {
    public boolean isBipartite(int[][] graph) {
        var visited = new boolean[graph.length];
        var colors = new boolean[graph.length];
        for (int i = 0; i < graph.length; i++) {
            if (!visited[i] && !dfs(graph, visited, colors, i)) return false;
        }
        return true;
    }

    private static boolean dfs(int[][] graph, boolean[] visited, boolean[] colors, int v) {
        visited[v] = true;
        for (int w : graph[v]) {
            if (visited[w]) {
                if (colors[w] == colors[v]) return false;
            } else {
                colors[w] = !colors[v];
                if (!dfs(graph, visited, colors, w)) return false;
            }
        }
        return true;
    }

    public static void main(String[] args) {
        new Solution().isBipartite(new int[][] {{2,3,5,6,7,8,9},{2,3,4,5,6,7,8,9},{0,1,3,4,5,6,7,8,9},{0,1,2,4,5,6,7,8,9},{1,2,3,6,9},{0,1,2,3,7,8,9},{0,1,2,3,4,7,8,9},{0,1,2,3,5,6,8,9},{0,1,2,3,5,6,7},{0,1,2,3,4,5,6,7}});
    }
}
