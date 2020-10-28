package KClosestPointsToOrigin;

import java.util.Collections;
import java.util.PriorityQueue;

class Solution {
    public int[][] kClosest(int[][] points, int K) {
        PriorityQueue<Point> closest = new PriorityQueue<>(K, Collections.reverseOrder());
        for (int[] point : points) {
            if (closest.size() < K) closest.offer(new Point(point[0], point[1]));
            else if (point[0] * point[0] + point[1] * point[1] < closest.peek().d) {
                closest.poll();
                closest.offer(new Point(point[0], point[1]));
            }
        }
        int[][] kClosest = new int[K][];
        for (int i = 0; i < K; i++) {
            Point closestPoint = closest.poll();
            kClosest[i] = new int[] { closestPoint.x, closestPoint.y };
        }
        return kClosest;
    }
}
class Point implements Comparable<Point> {
    public  int x, y, d;
    public Point(int x, int y) {
        this.x = x;
        this.y = y;
        this.d = x * x + y * y;
    }
    public int compareTo(Point o) {
        return Integer.compare(d, o.d);
    }
}
