package KthLargestElementInAStream;

import java.util.PriorityQueue;

class KthLargest {
    int k;
    PriorityQueue<Integer> pq;
    public KthLargest(int k, int[] nums) {
        this.k = k;
        pq = new PriorityQueue<>(k);
        for (int i = 0; i < k && i < nums.length; i++) pq.offer(nums[i]);
        for (int i = k; i < nums.length; i++) {
            if (nums[i] <= pq.peek()) continue;
            pq.poll();
            pq.offer(nums[i]);
        }
    }

    public int add(int val) {
        if (pq.size() < k) pq.offer(val);
        else if (val > pq.peek()) {
            pq.poll();
            pq.offer(val);
        }
        return pq.peek();
    }
}
