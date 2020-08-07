package MaximumNumberOfNonOverlappingSubstrings;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class Solution {
    public List<String> maxNumOfSubstrings(String s) {
        int[][] chars = new int[26][];
        for (int i = 0; i < chars.length; i++) chars[i] = new int[] { -1, -1 };
        for (int i = 0; i < s.length(); i++) {
            int offset = s.charAt(i) - 'a';
            if (chars[offset][0] == -1) chars[offset][0] = i;
            chars[offset][1] = i;
        }
        for (int i = 0; i < chars.length; i++) {
            if (chars[i][0] == -1) continue;
            int j = chars[i][0] + 1;
            while (j < chars[i][1]) {
                int offset = s.charAt(j) - 'a';
                j = chars[offset][0] < chars[i][0] ? chars[offset][0] + 1 : j + 1;
                chars[i][0] = Math.min(chars[i][0], chars[offset][0]);
                chars[i][1] = Math.max(chars[i][1], chars[offset][1]);
            }
        }
        Arrays.sort(chars, (l, r) -> l[1] < r[1] ? -1 : 1);
        List<String> substrings = new ArrayList<>();
        int end = -1;
        for (int[] aChar : chars) {
            if (aChar[0] == -1) continue;
            if (end == -1 || aChar[0] > end) {
                substrings.add(s.substring(aChar[0], aChar[1] + 1));
                end = aChar[1];
            }
        }
        return substrings;
    }
}
