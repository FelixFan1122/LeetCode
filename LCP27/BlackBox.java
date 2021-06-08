package LCP27;

import java.util.TreeMap;

public class BlackBox {

    private final int m;
    private final int n;
    private final int[] positiveSequenceIds;
    private final int[] negativeSequenceIds;
    private final TreeMap<Integer, Integer>[] positiveOpenings;
    private final TreeMap<Integer, Integer>[] negativeOpenings;

    public BlackBox(int n, int m) {
        this.n = n;
        this.m = m;
        positiveSequenceIds = new int[n + n + m + m];
        negativeSequenceIds = new int[n + n + m + m];
        positiveOpenings = (TreeMap<Integer, Integer>[]) new TreeMap[n + n + m + m];
        negativeOpenings = (TreeMap<Integer, Integer>[]) new TreeMap[n + n + m + m];
        for (int i = 0; i < n + n + m + m; i++) {
            if (i != 0 && i != m + n && positiveSequenceIds[i] == 0) dfs(i, 1);
            if (i != m && i != m + m + n && negativeSequenceIds[i] == 0) dfs(i, -1);
        }
    }

    public int open(int index, int direction) {
        if (positiveOpenings[index] != null) {
            positiveOpenings[index].put(positiveSequenceIds[index], index);
        }
        if (negativeOpenings[index] != null) {
            negativeOpenings[index].put(negativeSequenceIds[index], index);
        }
        int seq = direction > 0 ? positiveSequenceIds[index] : negativeSequenceIds[index];
        var openings = direction > 0 ? positiveOpenings[index] : negativeOpenings[index];
        return openings.higherEntry(seq) == null ? openings.firstEntry().getValue() : openings.higherEntry(seq).getValue();
    }

    public void close(int index) {
        if (positiveOpenings[index] != null) {
            positiveOpenings[index].remove(positiveSequenceIds[index]);
        }
        if (negativeOpenings[index] != null) {
            negativeOpenings[index].remove(negativeSequenceIds[index]);
        }
    }

    private void dfs(int vertex, int direction) {
        int seq = 1;
        var curr = new int[] { vertex, direction };
        var openings = new TreeMap<Integer, Integer>();
        do {
            if (curr[1] > 0) {
                positiveSequenceIds[curr[0]] = seq++;
                positiveOpenings[curr[0]] = openings;
            } else {
                negativeSequenceIds[curr[0]] = seq++;
                negativeOpenings[curr[0]] = openings;
            }
            curr = getNext(curr);
        } while (!(curr[0] == vertex && curr[1] == direction));
    }

    private int[] getNext(int[] curr) {
        int v = curr[0];
        var next = new int[] { 0, -curr[1] };
        if (curr[1] > 0) next[0] = m + m + n + n - v;
        else {
            if (v <= m) {
                next[0] = m + m - v;
            } else if (v <= m + m + n) {
                next[0] = (m * 4 + n + n - v) % (m + m + n + n);
            } else {
                next[0] = m * 4 + n + n - v;
            }
        }
        if (next[0] == 0 || next[0] == m + n) next[1] = -1;
        if (next[0] == m || next[0] == m + m + n) next[1] = 1;
        return next;
    }
}
