package RemoveInvalidParentheses;

import java.util.ArrayList;
import java.util.List;

public class Solution {
    public List<String> removeInvalidParentheses(String s) {
        var removed = new ArrayList<String>();
        remove(s, removed, '(', ')', 0, 0);
        return removed;
    }

    private void remove(String s, List<String> removed, char opening, char closing, int i, int lastRemoved) {
        int count = 0;
        while (i < s.length() && count >= 0) {
            if (s.charAt(i) == opening) count++;
            else if (s.charAt(i) == closing) count--;
            i++;
        }
        if (count >= 0) {
            s = new StringBuilder(s).reverse().toString();
            if (opening == '(') remove(s, removed, closing, opening, 0, 0);
            else removed.add(s);
        } else {
            for (int j = lastRemoved; j < i; j++) {
                if (s.charAt(j) == closing && (j == 0 || s.charAt(j - 1) != closing)) {
                    remove(s.substring(0, j) + s.substring(j + 1), removed, opening, closing, i - 1, j);
                }
            }
        }
    }
}
