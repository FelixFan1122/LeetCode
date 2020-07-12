namespace LeetCode.SubrectangleQueries
{
    public class SubrectangleQueries
    {
        private readonly int[][] rectangle;
        public SubrectangleQueries(int[][] rectangle)
        {
            this.rectangle = rectangle;
        }

        public void UpdateSubrectangle(int row1, int col1, int row2, int col2, int newValue)
        {
            for (var i = row1; i <= row2; i++)
            {
                for (var j = col1; j <= col2; j++)
                {
                    rectangle[i][j] = newValue;
                }
            }
        }

        public int GetValue(int row, int col)
        {
            return rectangle[row][col];
        }
    }
}