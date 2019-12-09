namespace SetMatrixZeroes
{
    public class Solution
    {
        public void SetZeroes(int[][] matrix)
        {
            if (matrix == null || matrix.Length == 0)
            {
                return;
            }

            var firstRowHasZero = HasZeroInFirstRow(matrix);
            var firstColumnHasZero = HasZeroInFirstColumn(matrix);
            MarkZero(matrix);
            SetZero(matrix);
            if (firstRowHasZero)
            {
                SetZeroFirstRow(matrix);
            }

            if (firstColumnHasZero)
            {
                SetZeroFirstColumn(matrix);
            }
        }

        private bool HasZeroInFirstRow(int[][] matrix)
        {
            for (var i = 0; i < matrix[0].Length; i++)
            {
                if (matrix[0][i] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        private bool HasZeroInFirstColumn(int[][] matrix)
        {
            for (var i = 0; i < matrix.Length; i++)
            {
                if (matrix[i][0] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        private void MarkZero(int[][] matrix)
        {
            for (var i = 1; i < matrix.Length; i++)
            {
                for (var j = 1; j < matrix[0].Length; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        matrix[i][0] = 0;
                        matrix[0][j] = 0;
                    }
                }
            }
        }

        private void SetZero(int[][] matrix)
        {
            for (var i = 1; i < matrix.Length; i++)
            {
                for (var j = 1; j < matrix[0].Length; j++)
                {
                    if (matrix[i][0] == 0 || matrix[0][j] == 0)
                    {
                        matrix[i][j] = 0;
                    }
                }
            }
        }

        private void SetZeroFirstRow(int[][] matrix)
        {
            for (var i = 0; i < matrix[0].Length; i++)
            {
                matrix[0][i] = 0;
            }
        }

        private void SetZeroFirstColumn(int[][] matrix)
        {
            for (var i = 0; i < matrix.Length; i++)
            {
                matrix[i][0] = 0;
            }
        }
    }
}