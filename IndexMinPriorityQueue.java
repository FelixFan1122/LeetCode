import java.util.Arrays;

public class IndexMinPriorityQueue<E extends Comparable<E>> {
    private int size;
    private int[] binaryHeap;
    private int[] indices;
    private E[] elements;

    public IndexMinPriorityQueue(int capacity) {
        binaryHeap = new int[capacity + 1];
        indices = new int[capacity + 1];
        elements = (E[]) new Comparable[capacity + 1];
        Arrays.fill(indices, -1);
    }

    public void change(int index, E element) {
        elements[index] = element;
        swim(indices[index]);
        sink(indices[index]);
    }

    public boolean contains(int index) {
        return indices[index] != -1;
    }

    public void delete(int index) {
        exchange(indices[index], size--);
        swim(indices[index]);
        sink(indices[index]);
        elements[binaryHeap[size + 1]] = null;
        indices[binaryHeap[size + 1]] = -1;
    }

    public int delMin() {
        int minIndex = binaryHeap[1];
        exchange(1, size--);
        sink(1);
        elements[binaryHeap[size + 1]] = null;
        indices[binaryHeap[size + 1]] = -1;
        return minIndex;
    }

    public void insert(int index, E element) {
        size++;
        indices[index] = size;
        binaryHeap[size] = index;
        elements[index] = element;
        swim(size);
    }

    public boolean isEmpty() {
        return size == 0;
    }

    public E min() {
        return elements[binaryHeap[1]];
    }

    public int minIndex() { return binaryHeap[1]; }

    public int size() {
        return size;
    }

    private void exchange(int i, int j) {
        int temp = binaryHeap[i];
        binaryHeap[i] = binaryHeap[j];
        binaryHeap[j] = temp;
        indices[binaryHeap[i]] = i;
        indices[binaryHeap[j]] = j;
    }

    private boolean less(int i, int j) { return elements[binaryHeap[i]].compareTo(elements[binaryHeap[j]]) < 0; }

    private void sink(int k) {
        while (k * 2 <= size) {
            int j = k * 2;
            if (j < size && less(j + 1, j)) j++;
            if (less(k, j)) break;
            exchange(k, j);
            k = j;
        }
    }

    private void swim(int k) {
        while (k > 1 && less(k, k / 2)) {
            exchange(k, k / 2);
            k /= 2;
        }
    }
}
