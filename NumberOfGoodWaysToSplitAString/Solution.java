package NumberOfGoodWaysToSplitAString;

public class Solution {
    public int numSplits(String s) {
        int[][] boundaries = new int[26][];
        for (int i = 0; i < 26; i++) boundaries[i] = new int[] { -1, -1 };
        int prefix = 0, suffix = 0;
        for (int i = 0; i < s.length(); i++) {
            if (boundaries[s.charAt(i) - 'a'][0] == -1) {
                boundaries[s.charAt(i) - 'a'][0] = i;
                suffix++;
            }
            boundaries[s.charAt(i) - 'a'][1] = i;
        }
        int count = 0;
        for (int i = 0; i < s.length(); i++) {
            if (boundaries[s.charAt(i) - 'a'][0] == i) prefix++;
            if (boundaries[s.charAt(i) - 'a'][1] == i) suffix--;
            if (prefix == suffix) count++;
        }
        return count;
    }
}
