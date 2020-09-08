package CanConvertStringInKMoves;

public class Solution {
    public boolean canConvertString(String s, String t, int k) {
        if (s.length() != t.length()) return false;
        int[] count = new int[26];
        for (int i = 0; i < s.length(); i++) {
            int shift = (t.charAt(i) - s.charAt(i) + 26) % 26;
            if (shift > 0) {
                count[shift]++;
                if (shift + 26 * (count[shift] - 1) > k) return false;
            }
        }
        return true;
    }
}
