package MostVisitedSectorInACircularTrack;

import java.util.ArrayList;
import java.util.List;

public class Solution {
    public List<Integer> mostVisited(int n, int[] rounds) {
        List<Integer> most = new ArrayList<>();
        if (rounds[0] > rounds[rounds.length - 1]) {
            for (int i = 1; i <= rounds[rounds.length - 1]; i++) most.add(i);
            for (int i = rounds[0]; i <= n; i++) most.add(i);
        } else {
            for (int i = rounds[0]; i <= rounds[rounds.length - 1]; i++) most.add(i);
        }
        return most;
    }
}
