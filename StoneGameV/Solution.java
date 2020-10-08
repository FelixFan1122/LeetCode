package StoneGameV;

public class Solution {
    public int stoneGameV(int[] stoneValue) {
        int[][] left = new int[stoneValue.length][stoneValue.length], right = new int[stoneValue.length][stoneValue.length], score = new int[stoneValue.length][stoneValue.length];
        for (int i = stoneValue.length - 1; i >= 0; i--) {
            int sum = stoneValue[i], run = 0, mid = i - 1;
            left[i][i] = right[i][i] = stoneValue[i];
            for (int j = i + 1; j < stoneValue.length; j++) {
                sum += stoneValue[j];
                while (mid < j && (run + stoneValue[mid + 1]) * 2 <= sum) run += stoneValue[++mid];
                if (mid >= i) score[i][j] = Math.max(score[i][j], left[i][mid]);
                if (mid + 2 <= j) score[i][j] = Math.max(score[i][j], right[mid + 2][j]);
                if (run * 2 == sum) score[i][j] = Math.max(score[i][j], right[mid + 1][j]);
                left[i][j] = Math.max(left[i][j - 1], score[i][j] + sum);
                right[i][j] = Math.max(right[i + 1][j], score[i][j] + sum);
            }
        }
        return score[0][stoneValue.length - 1];
    }
}
