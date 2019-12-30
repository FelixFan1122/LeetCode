using System.Collections.Generic;

namespace LeetCode.ValidSudoku
{
    public class Solution
    {
        public bool IsValidSudoku(char[][] board)
        {
            var rows = new HashSet<char>[9];
            var columns = new HashSet<char>[9];
            var boxes = new HashSet<char>[3][];
            for (var i = 0; i < 3; i++)
            {
                boxes[i] = new HashSet<char>[3];
            }

            for (var i = 0; i < board.Length; i++)
            {
                for (var j = 0; j < board[0].Length; j++)
                {
                    if (board[i][j] != '.')
                    {
                        if (rows[i] == null)
                        {
                            rows[i] = new HashSet<char>();
                        }

                        if (rows[i].Contains(board[i][j]))
                        {
                            return false;
                        }

                        if (columns[j] == null)
                        {
                            columns[j] = new HashSet<char>();
                        }

                        if (columns[j].Contains(board[i][j]))
                        {
                            return false;
                        }

                        if (boxes[i / 3][j / 3] == null)
                        {
                            boxes[i / 3][j / 3] = new HashSet<char>();
                        }

                        if (boxes[i / 3][j / 3].Contains(board[i][j]))
                        {
                            return false;
                        }

                        rows[i].Add(board[i][j]);
                        columns[j].Add(board[i][j]);
                        boxes[i / 3][j / 3].Add(board[i][j]);
                    }
                }
            }

            return true;
        }
    }
}