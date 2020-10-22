package MinimumNumberOfDaysToDisconnectIsland;

import java.util.ArrayList;
import java.util.Collection;

class Solution {
    public int minDays(int[][] grid) {
        int vertices = 0;
        for (int i = 0; i < grid.length; i++) for (int j = 0; j < grid[0].length; j++) grid[i][j] = grid[i][j] == 0 ? -1 : vertices++;
        if (vertices < 2) return vertices;
        Graph graph = new Graph(vertices);
        for (int i = 0; i < grid.length; i++) {
            for (int j = 0; j < grid[0].length; j++) {
                if (grid[i][j] >= 0) {
                    if (i > 0 && grid[i - 1][j] >= 0) graph.addEdge(grid[i - 1][j], grid[i][j]);
                    if (j > 0 && grid[i][j - 1] >= 0) graph.addEdge(grid[i][j - 1], grid[i][j]);
                }
            }
        }
        if (new ConnectedComponents(graph).count() != 1) return 0;
        if (new ArticulationVertexFinder(graph).findArticulationVertices().size() > 0) return 1;
        return 2;
    }
}
class ArticulationVertexFinder {
    ArrayList<Integer> arts;
    int[] order;
    int[] parent;
    int[] reachable;
    int ts;
    ArticulationVertexFinder(Graph graph) {
        arts = new ArrayList<>();
        order = new int[graph.vertices()];
        parent = new int[graph.vertices()];
        reachable = new int[graph.vertices()];
        ts = 1;
        dfs(0, graph);
        int count = 0;
        for (int w : graph.adj(0)) if (parent[w] == 0) count++;
        if (count > 1) arts.add(0);
    }
    void dfs(int v, Graph graph) {
        order[v] = reachable[v] = ts++;
        for (int w : graph.adj(v)) {
            if (order[w] == 0) {
                parent[w] = v;
                dfs(w, graph);
                reachable[v] = Math.min(reachable[v], reachable[w]);
                if (v != 0 && reachable[w] >= order[v]) arts.add(v);
            } else if (w != parent[v]) reachable[v] = Math.min(reachable[v], order[w]);
        }
    }
    Collection<Integer> findArticulationVertices() { return arts; }
}
class ConnectedComponents {
    int count;
    int[] ids;
    ConnectedComponents(Graph graph) {
        ids = new int[graph.vertices()];
        for (int i = 0; i < graph.vertices(); i++) {
            if (ids[i] == 0) {
                count++;
                dfs(i, graph);
            }
        }
    }
    int count() { return count; }
    void dfs(int v, Graph graph) {
        ids[v] = count;
        for (int w : graph.adj(v)) if (ids[w] == 0) dfs(w, graph);
    }
}
class Graph {
    ArrayList<Integer>[] graph;
    Graph(int vertices) {
        graph = (ArrayList<Integer>[])new ArrayList[vertices];
        for (int i = 0; i < vertices; i++) graph[i] = new ArrayList<>();
    }
    void addEdge(int v, int w) {
        graph[v].add(w);
        graph[w].add(v);
    }
    Collection<Integer> adj(int v) { return graph[v]; }
    int vertices() { return graph.length; }
}
