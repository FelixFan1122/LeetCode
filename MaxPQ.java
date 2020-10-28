public class MaxPQ<Key extends Comparable<Key>> {
    private final Key[] pq;
    private int n = 0;
    public MaxPQ(int maxN) { pq = (Key[])new Comparable[maxN + 1]; }
    public boolean isEmpty() { return n == 0; }
    public int size() { return n; }
    public void insert(Key v) {
        pq[++n] = v;
        swim(n);
    }
    public Key delMax() {
        Key max = pq[1];
        pq[1] = pq[n];
        pq[n--] = null;
        sink(1);
        return max;
    }
    private void sink(int i) {
        while (i * 2 <= n) {
            int greaterChild = i * 2;
            if (greaterChild < n && pq[greaterChild + 1].compareTo(pq[greaterChild]) > 0) greaterChild++;
            if (pq[i].compareTo(pq[greaterChild]) >= 0) break;
            exch(i, greaterChild);
            i = greaterChild;
        }
    }
    private void swim(int i) {
        while (i > 1 && pq[i].compareTo(pq[i / 2]) > 0) {
            exch(i, i / 2);
            i /= 2;
        }
    }
    private void exch(int i, int j) {
        Key temp = pq[i];
        pq[i] = pq[j];
        pq[j] = temp;
    }
}