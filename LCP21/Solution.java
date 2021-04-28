package LCP21;

import java.util.ArrayList;
import java.util.HashSet;
import java.util.LinkedList;

public class Solution {
    public int chaseGame(int[][] edges, int startA, int startB) {
        var graph = createGraph(edges);
        var cycle = detectCycle(graph);
        int[] distanceA = getDistances(graph, startA), distanceB = getDistances(graph, startB);
        if (cycle.size() > 3) {
            int entryPoint = -1, min = edges.length + 1;
            for (int i = 1; i <= edges.length; i++) {
                if (cycle.contains(i) && distanceB[i] < min) {
                    min = distanceB[i];
                    entryPoint = i;
                }
            }
            if (distanceA[entryPoint] - distanceB[entryPoint] > 1) return -1;
        }
        int max = 1;
        for (int i = 1; i <= edges.length; i++) {
            if (distanceA[i] - distanceB[i] > 1) {
                max = Math.max(max, distanceA[i]);
            }
        }
        return max;
    }
    private static ArrayList<Integer>[] createGraph(int[][] edges) {
        var graph = (ArrayList<Integer>[])new ArrayList[edges.length + 1];
        for (int i = 1; i <= edges.length; i++) graph[i] = new ArrayList<>();
        for (var edge : edges) {
            graph[edge[0]].add(edge[1]);
            graph[edge[1]].add(edge[0]);
        }
        return graph;
    }
    private static HashSet<Integer> detectCycle(ArrayList<Integer>[] graph) {
        var onStack = new boolean[graph.length];
        var parents = new int[graph.length];
        var cycle = new HashSet<Integer>();
        dfs(graph, onStack, parents, 1, cycle);
        return cycle;
    }
    private static boolean dfs(ArrayList<Integer>[] graph, boolean[] onStack, int[] parents, int vertex, HashSet<Integer> cycle) {
        onStack[vertex] = true;
        for (var w : graph[vertex]) {
            if (w == parents[vertex]) continue;
            if (onStack[w]) {
                while (vertex != w) {
                    cycle.add(vertex);
                    vertex = parents[vertex];
                }
                cycle.add(w);
                return true;
            }
            if (parents[w] > 0) continue;
            parents[w] = vertex;
            if (dfs(graph, onStack, parents, w, cycle)) return true;
        }
        onStack[vertex] = false;
        return false;
    }
    private static int[] getDistances(ArrayList<Integer>[] graph, int src) {
        var distances = new int[graph.length];
        int distance = -1;
        var q = new LinkedList<Integer>();
        q.offer(src);
        var visited = new boolean[graph.length];
        visited[src] = true;
        while (!q.isEmpty()) {
            distance++;
            int size = q.size();
            for (int i = 0; i < size; i++) {
                var v = q.poll();
                distances[v] = distance;
                for (var w : graph[v]) {
                    if (!visited[w]) {
                        visited[w] = true;
                        q.offer(w);
                    }
                }
            }
        }
        return distances;
    }
}
