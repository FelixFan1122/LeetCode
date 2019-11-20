namespace UniqueBinarySearchTrees
{
    public class Solution
    {
        public int NumTrees(int n)
        {
            long num = 1;
            for (var i = 1; i < n; i++)
            {
                num = num * (i * 4 + 2) / (i + 2);
            }

            return (int)num;
        }
    }
}