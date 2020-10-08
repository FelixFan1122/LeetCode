package FindLatestGroupOfSizeM;

import java.util.Arrays;

public class Solution {
    public int findLatestStep(int[] arr, int m) {
        if (m == arr.length) return arr.length;
        int last = -1;
        int[] start = new int[arr.length + 1], end = new int[arr.length + 1];
        Arrays.fill(start, -1);
        Arrays.fill(end, -1);
        for (int i = 0; i < arr.length; i++) {
            int position = arr[i];
            if (position == 1 || start[position - 1] == -1) {
                if (position == arr.length || end[position + 1] == -1) {
                    start[position] = position;
                    end[position] = position;
                    if (m == 1) last = i;
                } else {
                    if (end[position + 1] - position == m) last = i - 1;
                    end[position] = end[position + 1];
                    start[end[position]] = position;
                }
            } else {
                if (position == arr.length || end[position + 1] == -1) {
                    if (position - start[position - 1] == m) last = i - 1;
                    start[position] = start[position - 1];
                    end[start[position]] = position;
                } else {
                    if (end[position + 1] - position == m || position - start[position - 1] == m) last = i - 1;
                    start[end[position + 1]] = start[position - 1];
                    end[start[position - 1]] = end[position + 1];
                }
            }
        }
        return last == -1 ? -1 : last + 1;
    }
}
