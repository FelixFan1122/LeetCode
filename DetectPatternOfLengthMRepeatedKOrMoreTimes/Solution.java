package DetectPatternOfLengthMRepeatedKOrMoreTimes;

public class Solution {
    public boolean containsPattern(int[] arr, int m, int k) {
        int count = 0;
        for (int i = m; i < arr.length && count < m * (k - 1); i++) count = arr[i] == arr[i - m] ? count + 1 : 0;
        return count == m * (k - 1);
    }
}
