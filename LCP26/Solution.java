package LCP26;

public class Solution {
    private int count = 0, lastTridentNodeCount = 0;
    public int navigation(TreeNode root) {
        boolean l = postOrder(root.left), r = postOrder(root.right);
        if ((!l || !r) && lastTridentNodeCount < 2) count++;
        return count;
    }
    private boolean postOrder(TreeNode node) {
        if (node == null) return false;
        boolean l = postOrder(node.left), r = postOrder(node.right);
        if (node.left != null && node.right != null) {
            lastTridentNodeCount = l ? 1 : 0;
            lastTridentNodeCount = r ? lastTridentNodeCount + 1 : lastTridentNodeCount;
            lastTridentNodeCount = Math.max(1, lastTridentNodeCount);
            if (!l && !r) count++;
            return true;
        }
        return l || r;
    }
}

class TreeNode {
    int val;
    TreeNode left;
    TreeNode right;

    TreeNode(int x) {
        val = x;
    }
}
