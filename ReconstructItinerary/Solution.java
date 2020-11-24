package ReconstructItinerary;

import java.util.*;

public class Solution {
    private static final String ORIGIN = "JFK";
    public List<String> findItinerary(List<List<String>> tickets) {
        var graph = constructGraph(tickets);
        var itinerary = new Stack<String>();
        dfs(graph, ORIGIN, itinerary);
        Collections.reverse(itinerary);
        return itinerary;
    }

    private HashMap<String, PriorityQueue<String>> constructGraph(List<List<String>> tickets) {
        var graph = new HashMap<String, PriorityQueue<String>>();
        for (var ticket : tickets) graph.computeIfAbsent(ticket.get(0), x -> new PriorityQueue<>()).offer(ticket.get(1));
        return graph;
    }

    private void dfs(HashMap<String, PriorityQueue<String>> graph, String current, Stack<String> itinerary) {
        var neighbours = graph.get(current);
        while (neighbours != null && !neighbours.isEmpty()) dfs(graph, neighbours.poll(), itinerary);
        itinerary.push(current);
    }
}
