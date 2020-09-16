package ThousandSeparator;

public class Solution {
    public String thousandSeparator(int n) {
        StringBuilder sb = new StringBuilder();
        int count = 0;
        do {
            sb.append(n % 10);
            count++;
            n /= 10;
            if (count % 3 == 0 && n > 0) sb.append('.');
        } while (n > 0);
        return sb.reverse().toString();
    }
}
