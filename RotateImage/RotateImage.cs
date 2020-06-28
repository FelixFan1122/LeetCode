namespace LeetCode.RotateImage
{
    public class Solution
    {
        public void Rotate(int[][] matrix)
        {
            var n = matrix.Length;
            for (var i = 0; i <= n / 2 - 1; i++)
            {
                for (var j = i; j < n - 1 - i; j++)
                {
                    var previous = matrix[i][j];
                    for (var k = 0; k < 4; k++)
                    {
                        var next = matrix[j][n - 1 - i];
                        matrix[j][n - 1 - i] = previous;
                        previous = next;
                        var temp = i;
                        i = j;
                        j = n - 1 - temp;
                    }
                }
            }
        }
    }
}