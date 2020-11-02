package AllElementsInTwoBinarySearchTrees;

import java.util.ArrayList;
import java.util.LinkedList;
import java.util.List;
import java.util.Queue;

public class Solution {
    public List<Integer> getAllElements(TreeNode root1, TreeNode root2) {
        Queue<Integer> queue1 = new LinkedList<>(), queue2 = new LinkedList<>();
        traverse(root1, queue1);
        traverse(root2, queue2);
        List<Integer> sorted = new ArrayList<>();
        while (!queue1.isEmpty() && !queue2.isEmpty()) sorted.add(queue1.peek() < queue2.peek() ? queue1.poll() : queue2.poll());
        sorted.addAll(queue1);
        sorted.addAll(queue2);
        return sorted;
    }
    private void traverse(TreeNode node, Queue<Integer> inOrder) {
        if (node == null) return;
        if (node.left != null) traverse(node.left, inOrder);
        inOrder.offer(node.val);
        if (node.right != null) traverse(node.right, inOrder);
    }
}
 class TreeNode {
    int val;
    TreeNode left;
    TreeNode right;
}
