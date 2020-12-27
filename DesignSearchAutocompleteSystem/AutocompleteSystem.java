package DesignSearchAutocompleteSystem;

import java.util.ArrayList;
import java.util.List;
import java.util.PriorityQueue;

public class AutocompleteSystem {

    private final Node root = new Node();

    private Node current = root;
    private StringBuilder sb = new StringBuilder();

    public AutocompleteSystem(String[] sentences, int[] times) {
        for (int i = 0; i < sentences.length; i++) {
            var sentence = sentences[i];
            var node = root;
            for (int j = 0; j < sentence.length(); j++) {
                var offset = sentence.charAt(j) == ' ' ? 26 : sentence.charAt(j) - 'a';
                if (node.children[offset] == null) node.children[offset] = new Node();
                node = node.children[offset];
            }
            node.times = times[i];
        }
    }

    public List<String> input(char c) {
        if (c == '#') {
            current = root;
            var sentence = sb.toString();
            sb = new StringBuilder();
            var node = root;
            for (int j = 0; j < sentence.length(); j++) {
                var offset = sentence.charAt(j) == ' ' ? 26 : sentence.charAt(j) - 'a';
                if (node.children[offset] == null) node.children[offset] = new Node();
                node = node.children[offset];
            }
            node.times++;
            return new ArrayList<>();
        }
        sb.append(c);
        if (current == null) return new ArrayList<>();
        int offset = c == ' ' ? 26 : c - 'a';
        current = current.children[offset];
        if (current == null) return new ArrayList<>();
        var pq = new PriorityQueue<Result>();
        collect(current, pq, sb.toString());
        var results = new ArrayList<String>();
        for (int i = 0; i < 3 && !pq.isEmpty(); i++) results.add(pq.poll().val);
        return results;
    }

    private static void collect(Node node, PriorityQueue<Result> pq, String prefix) {
        if (node.times > 0) pq.offer(new Result(prefix, node.times));
        for (int i = 0; i < 27; i++) if (node.children[i] != null) collect(node.children[i], pq, prefix + (i == 26 ? " " : (char)('a' + i)));
    }

    private static class Result implements Comparable<Result> {
        public String val;
        public int times;
        public Result(String val, int times) {
            this.val = val;
            this.times = times;
        }
        public int compareTo(Result o) {
            return times == o.times ? val.compareTo(o.val) : Integer.compare(o.times, times);
        }
    }

    private static class Node {
        int times;
        Node[] children = new Node[27];
    }

    public static void main(String[] args) {
        var sut = new AutocompleteSystem(new String[] {"i love you","island","iroman","i love leetcode"}, new int[] {5,3,2,2});
        sut.input('i');
        sut.input(' ');
        sut.input('a');
        sut.input('#');
    }
}
