package MinimumInsertionsToBalanceAParenthesesString;

public class Solution {
    public int minInsertions(String s) {
        int left = 0, insertions = 0, i = 0;
        while (i < s.length()) {
            if (s.charAt(i) == '(') {
                left++;
                i++;
            } else {
                if (left == 0) insertions++;
                else left--;
                if (i == s.length() - 1 || s.charAt(i + 1) == '(') {
                    insertions++;
                    i++;
                } else {
                    i += 2;
                }
            }
        }
        return insertions + left * 2;
    }
}
