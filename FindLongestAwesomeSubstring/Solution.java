package FindLongestAwesomeSubstring;

import java.util.HashMap;
import java.util.Map;

public class Solution {
    public int longestAwesome(String s) {
        int max = 0, current = 0;
        Map<Integer, Integer> previous = new HashMap<>();
        previous.put(0, -1);
        for (int i = 0; i < s.length(); i++) {
            current ^= 1 << (s.charAt(i) - '0');
            if (previous.containsKey(current)) max = Math.max(max, i - previous.get(current));
            for (int j = 0; j < 10; j++) if (previous.containsKey(current ^ (1 << j))) max = Math.max(max, i - previous.get(current ^ (1 << j)));
            if (!previous.containsKey(current)) previous.put(current, i);
        }
        return max;
    }
}
