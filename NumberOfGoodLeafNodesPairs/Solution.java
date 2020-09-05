package NumberOfGoodLeafNodesPairs;

public class Solution {
    private int count = 0;

    public int countPairs(TreeNode root, int distance) {
        if (distance < 2) return 0;
        dfs(root, distance);
        return count;
    }

    private int[] dfs(TreeNode node, int distance) {
        int[] leftLeaves = node.left == null ? new int[distance - 1] : dfs(node.left, distance);
        int[] rightLeaves = node.right == null ? new int[distance - 1] : dfs(node.right, distance);
        int[] leaves = new int[distance - 1];
        if (node.left == null && node.right == null) {
            leaves[0]++;
            return leaves;
        }
        for (int i = 1; i < distance - 1; i++) leaves[i] = leftLeaves[i - 1] + rightLeaves[i - 1];
        for (int i = 0; i < distance - 1; i++) {
            for (int j = 0; i + j + 2 <= distance; j++) count += leftLeaves[i] * rightLeaves[j];
        }
        return leaves;
    }

    private class TreeNode {
        int val;
        TreeNode left;
        TreeNode right;

        TreeNode() {
        }

        TreeNode(int val) {
            this.val = val;
        }

        TreeNode(int val, TreeNode left, TreeNode right) {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}
