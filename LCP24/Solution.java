package LCP24;

import java.util.Collections;
import java.util.PriorityQueue;

public class Solution {
    public int[] numsGame(int[] nums) {
        for (int i = 0; i < nums.length; i++) nums[i] -= i;
        var ops = new int[nums.length];
        PriorityQueue<Integer> greater = new PriorityQueue<>(), smaller = new PriorityQueue<>(Collections.reverseOrder());
        long greaterSum = 0, smallerSum = 0;
        for (int i = 0; i < nums.length; i++) {
            if (greater.size() == smaller.size()) {
                smaller.offer(nums[i]);
                smallerSum += nums[i];
                smallerSum -= smaller.peek();
                greaterSum += smaller.peek();
                greater.offer(smaller.poll());
            } else {
                greater.offer(nums[i]);
                greaterSum += nums[i];
                greaterSum -= greater.peek();
                smallerSum += greater.peek();
                smaller.offer(greater.poll());
            }
            var median = greater.peek();
            ops[i] = (int)(((long)median * smaller.size() - smallerSum + greaterSum - (long)median * greater.size()) % 1000_000_007);
        }
        return ops;
    }
}
