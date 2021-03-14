package MaximumAveragePassRatio;

import java.util.PriorityQueue;

public class Solution {
    public double maxAverageRatio(int[][] classes, int extraStudents) {
        var pq = new PriorityQueue<double[]>((x, y) -> Double.compare(y[2], x[2]));
        for (var c : classes) pq.offer(new double[] { c[0], c[1], (double)(c[1] - c[0]) / (c[1] * (c[1] + 1)) });
        while (extraStudents > 0) {
            var c = pq.poll();
            c[0] += 1;
            c[1] += 1;
            c[2] = (c[1] - c[0]) / (c[1] * (c[1] + 1));
            pq.offer(c);
            extraStudents--;
        }
        double sum = 0;
        while (!pq.isEmpty()) {
            var c = pq.poll();
            sum += c[0] / c[1];
        }
        return sum / classes.length;
    }
}
