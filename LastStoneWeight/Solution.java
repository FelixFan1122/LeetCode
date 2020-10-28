package LastStoneWeight;

import java.util.Collections;
import java.util.PriorityQueue;

public class Solution {
    public int lastStoneWeight(int[] stones) {
        PriorityQueue<Integer> pq = new PriorityQueue<>(stones.length, Collections.reverseOrder());
        for (int stone : stones) pq.offer(stone);
        while (pq.size() > 1) {
            int heaviest = pq.poll();
            int secondHeaviest = pq.poll();
            if (heaviest > secondHeaviest) pq.offer(heaviest - secondHeaviest);
        }
        return pq.isEmpty() ? 0 : pq.poll();
    }
}
