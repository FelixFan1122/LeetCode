package FindAValueOfAMysteriousFunctionClosestToTarget;

import java.util.HashSet;

public class Solution {
    public int closestToTarget(int[] arr, int target) {
        int closest = Math.abs(arr[0] - target);
        HashSet<Integer> previous = new HashSet<>();
        previous.add(arr[0]);
        for (var i = 1; i < arr.length; i++) {
            HashSet<Integer> current = new HashSet<>();
            current.add(arr[i]);
            closest = Math.min(closest, Math.abs(arr[i] - target));
            for (int andSum : previous) {
                current.add(andSum & arr[i]);
                closest = Math.min(closest, Math.abs((andSum & arr[i]) - target));
            }
            previous = current;
        }
        return closest;
    }
}
