namespace SearchA2DMatrixII
{
    public class Solution
    {
        public bool SearchMatrix(int[,] matrix, int target)
        {
            if (matrix == null || matrix.Length == 0)
            {
                return false;
            }

            var row = 0;
            var column = matrix.GetLength(1) - 1;
            while (row < matrix.GetLength(0) && column >= 0)
            {
                if (matrix[row, column] == target)
                {
                    return true;
                }
                else if (matrix[row, column] < target)
                {
                    row++;
                }
                else
                {
                    column--;
                }
            }

            return false;
        }
    }
}