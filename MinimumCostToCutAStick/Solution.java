package MinimumCostToCutAStick;

import java.util.Arrays;

public class Solution {
    public int minCost(int n, int[] cuts) {
        Arrays.sort(cuts);
        int[] original = cuts;
        cuts = new int[original.length + 2];
        cuts[0] = 0;
        System.arraycopy(original, 0, cuts, 1, original.length);
        cuts[cuts.length - 1] = n;
        int[][] dp = new int[cuts.length][cuts.length];
        for (int i = cuts.length - 2; i > 0; i--) {
            for (int j = i; j < cuts.length - 1; j++) {
                if (j > i) dp[i][j] = Integer.MAX_VALUE;
                for (int k = i; k <= j; k++) dp[i][j] = Math.min(dp[i][j], dp[i][k - 1] + dp[k + 1][j]);
                dp[i][j] += cuts[j + 1] - cuts[i - 1];
            }
        }
        return dp[1][cuts.length - 2];
    }
}
