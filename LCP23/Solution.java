package LCP23;

import java.util.LinkedList;
import java.util.Queue;

public class Solution {
    public boolean isMagic(int[] target) {
        int n = target.length;
        LinkedList<Integer> q = new LinkedList<>(), aux = new LinkedList<>();
        for (int i = 1; i <= n; i++) q.offer(i);
        shuffle(q, aux);
        int k = 0;
        while (k < n && q.peek() == target[k]) {
            k++;
            q.poll();
        }
        if (k == 0) return false;
        int index = k;
        while (index < n) {
            shuffle(q, aux);
            for (int i = 0; i < k && index < n; i++, index++) {
                if (q.peek() != target[index]) return false;
                q.poll();
            }
        }
        return true;
    }
    private void shuffle(Queue<Integer> q, Queue<Integer> aux) {
        int size = q.size();
        for (int i = 0; i < size; i++) {
            if ((i & 1) == 0) aux.offer(q.poll());
            else q.offer(q.poll());
        }
        while (!aux.isEmpty()) q.offer(aux.poll());
    }

    public static void main(String[] args) {
        new Solution().isMagic(new int[] { 2, 4, 3, 1, 5 });
    }
}
