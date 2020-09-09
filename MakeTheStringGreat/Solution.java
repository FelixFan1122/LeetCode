package MakeTheStringGreat;

public class Solution {
    public String makeGood(String s) {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < s.length(); i++) {
            if (sb.length() > 0 && Character.toLowerCase(sb.charAt(sb.length() - 1)) == Character.toLowerCase(s.charAt(i)) && sb.charAt(sb.length() - 1) != s.charAt(i)) sb.deleteCharAt(sb.length() - 1);
            else sb.append(s.charAt(i));
        }
        return sb.toString();
    }
}
