public class MergeSortBottomUp {
    public void sort(int[] a) {
        int[] b = new int[a.length];
        for (int size = 1; size < a.length; size += size) {
            for (int i = 0; i < a.length - size; i += size + size) {
                int end = Math.min(i + size + size, a.length);
                System.arraycopy(a, i, b, i, end - i);
                int l = i, r = i + size;
                for (int j = i; j < end; j++) {
                    if (l >= i + size) a[j] = b[r++];
                    else if (r >= end) a[j] = b[l++];
                    else if (b[l] < b[r]) a[j] = b[l++];
                    else a[j] = b[r++];
                }
            }
        }
    }
}
