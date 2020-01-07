namespace LeetCode.GameOfLife
{
    public class Solution
    {
        private const int Dead = 0;
        private const int Live = 1;
        private const int Living = 2;
        private const int Dying = 3;
        private const int UnderPopulation = 2;
        private const int OverPopulation = 3;
        private const int Reproduction = 3;

        private static readonly int[][] Neighbours = new[]
        {
            new[] { -1, -1 },
            new[] { -1, 0 },
            new[] { -1, 1 },
            new[] { 0, -1 },
            new[] { 0, 1 },
            new[] { 1, -1 },
            new[] { 1, 0 },
            new[] { 1, 1 }
        };

        public void GameOfLife(int[][] board)
        {
            for (var i = 0; i < board.Length; i++)
            {
                for (var j = 0; j < board[0].Length; j++)
                {
                    var liveNeighbours = CountLiveNeighbours(board, i, j);
                    if (board[i][j] == Dead)
                    {
                        if (liveNeighbours == Reproduction)
                        {
                            board[i][j] = Living;
                        }
                    }
                    else
                    {
                        if (liveNeighbours < UnderPopulation || liveNeighbours > OverPopulation)
                        {
                            board[i][j] = Dying;
                        }
                    }
                }
            }

            for (var i = 0; i < board.Length; i++)
            {
                for (var j = 0; j < board[0].Length; j++)
                {
                    if (board[i][j] == Living)
                    {
                        board[i][j] = Live;
                    }
                    else if (board[i][j] == Dying)
                    {
                        board[i][j] = Dead;
                    }
                }
            }
        }

        private int CountLiveNeighbours(int[][] board, int i, int j)
        {
            var lives = 0;
            foreach (var neighbour in Neighbours)
            {
                var neighbourI = i + neighbour[0];
                var neighbourJ = j + neighbour[1];
                if (neighbourI >= 0 && neighbourI < board.Length && neighbourJ >= 0 && neighbourJ < board[0].Length && (board[neighbourI][neighbourJ] == Live || board[neighbourI][neighbourJ] == Dying))
                {
                    lives++;
                }
            }

            return lives;
        }
    }
}