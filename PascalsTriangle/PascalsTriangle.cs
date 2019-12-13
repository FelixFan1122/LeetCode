using System.Collections.Generic;

namespace PascalsTriangle
{
    public class Solution
    {
        public IList<IList<int>> Generate(int numRows)
        {
            if (numRows <= 0)
            {
                return new List<IList<int>>();
            }

            var pascalTriangle = new List<IList<int>>(numRows);
            var firstRow = new List<int>(1);
            firstRow.Add(1);
            pascalTriangle.Add(firstRow);
            for (var i = 1; i < numRows; i++)
            {
                var row = new List<int>(i + 1);
                row.Add(1);

                for (var j = 1; j < i; j++)
                {
                    row.Add(pascalTriangle[i - 1][j - 1] + pascalTriangle[i - 1][j]);
                }

                row.Add(1);

                pascalTriangle.Add(row);
            }

            return pascalTriangle;
        }
    }
}