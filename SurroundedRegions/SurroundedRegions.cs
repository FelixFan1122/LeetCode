namespace LeetCode.SurroundedRegions
{
    public class Solution
    {
        private const char O = 'O';
        private const char M = 'M';
        private const char X = 'X';
        private static int[][] neighbours = new[] { new[] { -1, 0 }, new[] { 1, 0 }, new[] { 0, -1 }, new[] { 0, 1 } };
        public void Solve(char[][] board)
        {
            if (board == null || board.Length == 0 || board[0].Length == 0)
            {
                return;
            }

            for (var i = 0; i < board.Length; i++)
            {
                if (board[i][0] == O)
                {
                    Mark(board, i, 0);
                }

                if (board[i][board[i].Length - 1] == O)
                {
                    Mark(board, i, board[i].Length - 1);
                }
            }

            for (var i = 0; i < board[0].Length; i++)
            {
                if (board[0][i] == O)
                {
                    Mark(board, 0, i);
                }

                if (board[board.Length - 1][i] == O)
                {
                    Mark(board, board.Length - 1, i);
                }
            }

            for (var i = 0; i < board.Length; i++)
            {
                for (var j = 0; j < board[i].Length; j++)
                {
                    if (board[i][j] == O)
                    {
                        board[i][j] = X;
                    }
                    else if (board[i][j] == M)
                    {
                        board[i][j] = O;
                    }
                }
            }
        }

        private void Mark(char[][] board, int i, int j)
        {
            board[i][j] = M;
            for (var k = 0; k < neighbours.Length; k++)
            {
                i += neighbours[k][0];
                j += neighbours[k][1];
                if (i >= 0 && i < board.Length && j >= 0 && j < board[0].Length && board[i][j] == O)
                {
                    Mark(board, i, j);
                }

                i -= neighbours[k][0];
                j -= neighbours[k][1];
            }
        }
    }
}