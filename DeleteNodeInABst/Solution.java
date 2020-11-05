package DeleteNodeInABst;

public class Solution {
    public TreeNode deleteNode(TreeNode root, int key) {
        if (root == null) return null;
        if (root.val < key) root.right = deleteNode(root.right, key);
        else if (root.val > key) root.left = deleteNode(root.left, key);
        else {
            if (root.left == null) return root.right;
            if (root.right == null) return root.left;
            TreeNode successor = min(root.right);
            successor.right = deleteMin(root.right);
            successor.left = root.left;
            return successor;
        }
        return root;
    }
    private TreeNode min(TreeNode root) {
        if (root == null) return null;
        while (root.left != null) root = root.left;
        return root;
    }
    private TreeNode deleteMin(TreeNode root) {
        if (root == null) return null;
        if (root.left == null) return root.right;
        root.left = deleteMin(root.left);
        return root;
    }
    private static class TreeNode {
        int val;
        TreeNode left, right;
        TreeNode(int val) { this.val = val; }
    }
}
