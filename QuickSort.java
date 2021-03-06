public class QuickSort {
    public static void sort(int[] a) {
        sort(a, 0, a.length - 1);
    }

    private static void sort(int[] a, int l, int r) {
        if (l >= r) return;
        int p = medianThree(a, l, r);
        int i = l, j = r - 1;
        while(i < j) {
            while (a[++i] < p) ;
            while (a[--j] > p) ;
            if (i < j) exch(a, i, j);
        }
        exch(a, i, r - 1);
        sort(a, l, i - 1);
        sort(a, i + 1, r);
    }

    private static  int medianThree(int[] a, int l, int r) {
        int m = l + (r - l) / 2;
        if (a[l] > a[m]) exch(a, l, m);
        if (a[l] > a[r]) exch(a, l, r);
        if (a[m] > a[r]) exch(a, m, r);
        exch(a, m, r - 1);
        return a[r - 1];
    }

    private static void exch(int[] a, int i, int j) {
        int temp = a[i];
        a[i] = a[j];
        a[j] = temp;
    }
}
