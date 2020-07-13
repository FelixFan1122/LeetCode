namespace LeetCode.KthAncestorOfATreeNode
{
    public class TreeAncestor
    {
        private readonly int[] parent;
        public TreeAncestor(int n, int[] parent)
        {
            this.parent = parent;
        }

        public int GetKthAncestor(int node, int k)
        {
            while (k > 0 && node != 0)
            {
                node = parent[node];
                k--;
            }

            return k == 0 ? node : -1;
        }
    }
}