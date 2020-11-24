package AllPathsFromSourceToTarget;

import java.util.ArrayList;
import java.util.List;

public class Solution {
    public List<List<Integer>> allPathsSourceTarget(int[][] graph) {
        var path = new ArrayList<Integer>();
        var paths = new ArrayList<List<Integer>>();
        path.add(0);
        dfs(graph, paths, 0, path);
        return paths;
    }

    private static void dfs(int[][] graph, ArrayList<List<Integer>> paths, int v, ArrayList<Integer> path) {
        if (v == graph.length - 1) {
            paths.add(new ArrayList<>(path));
        } else {
            for (int i = 0; i < graph[v].length; i++) {
                path.add(graph[v][i]);
                dfs(graph, paths, graph[v][i], path);
                path.remove(path.size() - 1);
            }
        }
    }
}
