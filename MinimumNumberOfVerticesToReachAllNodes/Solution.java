package MinimumNumberOfVerticesToReachAllNodes;

import java.util.ArrayList;
import java.util.BitSet;
import java.util.List;

public class Solution {
    public List<Integer> findSmallestSetOfVertices(int n, List<List<Integer>> edges) {
        BitSet reached = new BitSet(n);
        for (List<Integer> edge : edges) {
            reached.set(edge.get(1));
        }
        List<Integer> vertices = new ArrayList<>();
        for (int i = 0; i < n; i++) if (!reached.get(i)) vertices.add(i);
        return vertices;
    }
}
