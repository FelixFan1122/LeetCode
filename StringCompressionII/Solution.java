package StringCompressionII;

import java.util.Arrays;

public class Solution {
    public int getLengthOfOptimalCompression(String s, int k) {
        int[][] dp = new int[s.length() + 1][k + 1];
        for (int[] ints : dp) Arrays.fill(ints, Integer.MAX_VALUE >> 1);
        dp[0][0] = 0;
        for (int i = 1; i <= s.length(); i++) {
            for (int j = 0; j <= Math.min(k, i); j++) {
                dp[i][j] = j == 0 ? (Integer.MAX_VALUE >> 1) : dp[i - 1][j - 1];
                int count = 0, deleted = 0;
                for (int ii = i; ii > 0 && deleted <= j; ii--) {
                    if (s.charAt(ii - 1) == s.charAt(i - 1)) {
                        count++;
                        dp[i][j] = Math.min(dp[i][j], dp[ii - 1][j - deleted] + (count == 1 ? 1 : String.valueOf(count).length() + 1));
                    } else {
                        deleted++;
                    }
                }
            }
        }
        return dp[s.length()][k];
    }
}
