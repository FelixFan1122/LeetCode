package MinimumNumberOfRefuelingStops;

import java.util.Collections;
import java.util.PriorityQueue;

public class Solution {
    public int minRefuelStops(int target, int startFuel, int[][] stations) {
        if (stations.length == 0) return target > startFuel ? -1 : 0;
        int tank = startFuel;
        PriorityQueue<Integer> refuels = new PriorityQueue<>(Collections.reverseOrder());
        for (int i = 0; i < stations.length; i++) {
            int distance = i == 0 ? stations[i][0] : stations[i][0] - stations[i - 1][0];
            while (tank < distance) {
                if (refuels.isEmpty()) return -1;
                tank += refuels.poll();
            }
            tank -= distance;
            refuels.offer(stations[i][1]);
        }
        while (tank < target - stations[stations.length - 1][0]) {
            if (refuels.isEmpty()) return -1;
            tank += refuels.poll();
        }
        return stations.length - refuels.size();
    }
}
