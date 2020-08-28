package NumberOfSubArraysWithOddSum;

public class Solution {
    public int numOfSubarrays(int[] arr) {
        int even = 1, odd = 0, sum = 0;
        long count = 0;
        for (int num : arr) {
            sum += num;
            if ((sum & 1) == 0) {
                count += odd;
                even++;
            } else {
                count += even;
                odd++;
            }
        }
        return (int)(count % 1000000007);
    }
}
