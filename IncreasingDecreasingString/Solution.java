package IncreasingDecreasingString;

public class Solution {
    public String sortString(String s) {
        int[] count = new int[26];
        for (int i = 0; i < s.length(); i++) count[s.charAt(i) - 'a']++;
        int j = 0;
        char[] sorted = new char[s.length()];
        while (j < s.length()) {
            for (int i = 0; i < 26; i++) {
                if (count[i] == 0) continue;
                sorted[j++] = (char)('a' + i);
                count[i]--;
            }
            for (int i = 25; i >= 0; i--) {
                if (count[i] == 0) continue;
                sorted[j++] = (char)('a' + i);
                count[i]--;
            }
        }
        return new String(sorted);
    }
}
