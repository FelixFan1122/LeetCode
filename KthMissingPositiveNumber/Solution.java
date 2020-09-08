package KthMissingPositiveNumber;

public class Solution {
    public int findKthPositive(int[] arr, int k) {
        if (arr[arr.length - 1] - arr.length < k) return k + arr.length;
        int left = 0, right = arr.length - 1;
        while (left < right) {
            int mid = left + (right - left) / 2;
            if (arr[mid] - mid - 1 < k) left = mid + 1;
            else right = mid;
        }
        return left + k;
    }
}
