package BulbSwitcherIV;

public class Solution {
    public int minFlips(String target) {
        int flips = target.charAt(0) == '0' ? 0 : 1;
        for (int i = 0; i < target.length() - 1; i++) if (target.charAt(i) != target.charAt(i + 1)) flips++;
        return flips;
    }
}
