package CountOddNumbersInAnIntervalRange;

public class Solution {
    public int countOdds(int low, int high) {
        return (high - low + 1) / 2 + ((high - low + 1 & 1) != 0 && (low & 1) != 0 ? 1 : 0);
    }
}
