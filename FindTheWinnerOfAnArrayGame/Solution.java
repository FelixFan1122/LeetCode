package FindTheWinnerOfAnArrayGame;

public class Solution {
    public int getWinner(int[] arr, int k) {
        int winner = arr[0], wins = 0;
        for (int i = 1; i < arr.length && wins < k; i++) {
            wins = arr[i] > winner ? 1 : wins + 1;
            winner = Math.max(winner, arr[i]);
        }
        return winner;
    }
}
