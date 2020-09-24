package StoneGameIII;

import java.util.Arrays;

public class Solution {
    public String stoneGameIII(int[] stoneValue) {
        int[] dp = new int[stoneValue.length];
        int[] suffixSums = new int[stoneValue.length + 1];
        suffixSums[stoneValue.length] = 0;
        for (int i = stoneValue.length - 1; i >= 0; i--) suffixSums[i] = suffixSums[i + 1] + stoneValue[i];
        Arrays.fill(dp, Integer.MIN_VALUE);
        dp[stoneValue.length - 1] = stoneValue[stoneValue.length - 1];
        for (int i = stoneValue.length - 2; i >= 0; i--) {
            for (int j = 1; j <= 3; j++) {
                dp[i] = Math.max(dp[i], i + j < stoneValue.length ? suffixSums[i] - dp[i + j] : suffixSums[i]);
            }
        }
        return dp[0] == suffixSums[0] - dp[0] ? "Tie" : dp[0] < suffixSums[0] - dp[0] ? "Bob" : "Alice";
    }
}
