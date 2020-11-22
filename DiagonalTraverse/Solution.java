package DiagonalTraverse;

import java.util.ArrayList;

public class Solution {
    public int[] findDiagonalOrder(int[][] matrix) {
        if (matrix == null || matrix.length == 0 || matrix[0].length == 0) return new int[0];
        boolean reverse = true;
        int index = 0;
        var diagonal = new ArrayList<Integer>();
        int[] diagonalOrder = new int[matrix.length * matrix[0].length];
        for (int c = 0; c < matrix[0].length; c++) {
            int i = 0, j = c;
            while (i < matrix.length && j >= 0) diagonal.add(matrix[i++][j--]);
            if (reverse) {
                for (int k = diagonal.size() - 1; k >= 0; k--) diagonalOrder[index++] = diagonal.get(k);
            } else {
                for (int k = 0; k < diagonal.size(); k++) diagonalOrder[index++] = diagonal.get(k);
            }
            reverse = !reverse;
            diagonal.clear();
        }
        for (int r = 1; r < matrix.length; r++) {
            int i = r, j = matrix[0].length - 1;
            while (i < matrix.length && j >= 0) diagonal.add(matrix[i++][j--]);
            if (reverse) {
                for (int k = diagonal.size() - 1; k >= 0; k--) diagonalOrder[index++] = diagonal.get(k);
            } else {
                for (int k = 0; k < diagonal.size(); k++) diagonalOrder[index++] = diagonal.get(k);
            }
            reverse = !reverse;
            diagonal.clear();
        }
        return diagonalOrder;
    }
}
