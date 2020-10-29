public class MergeSortTopDown {
    public void sort(int[] a) {
        sort(a, 0, a.length - 1, new int[a.length]);
    }

    private void sort(int[] a, int l, int r, int[] b) {
        if (l >= r) return;
        int mid = l + (r - l) / 2;
        sort(a, l, mid, b);
        sort(a, mid + 1, r, b);
        int ll = l;
        int rr = mid + 1;
        for (int i = l; i <= r; i++) {
            if (ll > mid) b[i] = a[rr++];
            else if (rr > r) b[i] = a[ll++];
            else if (a[ll] < a[rr]) b[i] = a[ll++];
            else b[i] = a[rr++];
        }
        System.arraycopy(b, l, a, l, r + 1 - l);
    }
}
