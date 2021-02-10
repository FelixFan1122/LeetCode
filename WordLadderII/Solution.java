package WordLadderII;

import java.util.*;

public class Solution {
    public List<List<String>> findLadders(String beginWord, String endWord, List<String> wordList) {
        var ladders = new ArrayList<List<String>>();
        wordList.add(beginWord);
        var endIndex = wordList.indexOf(endWord);
        if (endIndex < 0) return ladders;
        var graph = constructGraph(wordList);
        var q = new LinkedList<List<Integer>>();
        q.offer(List.of(graph.length - 1));
        var distance = new int[graph.length];
        Arrays.fill(distance, Integer.MAX_VALUE);
        distance[distance.length - 1] = 0;
        while (!q.isEmpty() && distance[endIndex] == Integer.MAX_VALUE) {
            var size = q.size();
            for (int i = 0; i < size; i++) {
                var ladder = q.poll();
                var word = ladder.get(ladder.size() - 1);
                for (var neighbour : graph[word]) {
                    if (distance[word] + 1 <= distance[neighbour]) {
                        var clone = new ArrayList<>(ladder);
                        clone.add(neighbour);
                        q.offer(clone);
                        distance[neighbour] = distance[word] + 1;
                        if (neighbour.equals(endIndex)) {
                            var path = new ArrayList<String>();
                            for (var j : clone) path.add(wordList.get(j));
                            ladders.add(path);
                        }
                    }
                }
            }
        }
        return ladders;
    }
    ArrayList<Integer>[] constructGraph(List<String> vertices) {
        var graph = (ArrayList<Integer>[])new ArrayList[vertices.size()];
        for (int i = 0; i < graph.length; i++) graph[i] = new ArrayList<>();
        for (int i = 0; i < vertices.size(); i++) {
            for (int j = i + 1; j < vertices.size(); j++) {
                if (isConnected(vertices.get(i), vertices.get(j))) {
                    graph[i].add(j);
                    graph[j].add(i);
                }
            }
        }
        return graph;
    }
    boolean isConnected(String word1, String word2) {
        int count = 0;
        for (int i = 0; i < word1.length() && count < 2; i++) {
            if (word1.charAt(i) != word2.charAt(i)) count++;
        }
        return count < 2;
    }
}
