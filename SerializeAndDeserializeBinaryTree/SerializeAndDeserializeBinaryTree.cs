using System;
using System.Text;

namespace LeetCode.SerializeAndDeserializeBinaryTree
{
    public class Codec
    {
        private const char Delimiter = ',';
        private const string Null = "n";

        // Encodes a tree to a single string.
        public string serialize(TreeNode root)
        {
            var serialized = new StringBuilder();
            serialize(root, serialized);
            return serialized.Remove(0, 1).ToString();
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            if (data == null)
            {
                return null;
            }

            return deserialize(data.Split(Delimiter), 0).Item1;
        }

        private void serialize(TreeNode node, StringBuilder serialized)
        {
            serialized.Append(Delimiter);
            if (node == null)
            {
                serialized.Append(Null);
            }
            else
            {
                serialized.Append(node.val);
                serialize(node.left, serialized);
                serialize(node.right, serialized);
            }
        }

        private Tuple<TreeNode, int> deserialize(string[] data, int start)
        {
            if (data.Length == 0 || start >= data.Length || data[start] == Null)
            {
                return new Tuple<TreeNode, int>(null, 1);
            }

            var node = new TreeNode(int.Parse(data[start]));
            var left = deserialize(data, start + 1);
            var right = deserialize(data, start + 1 + left.Item2);
            node.left = left.Item1;
            node.right = right.Item1;
            return new Tuple<TreeNode, int>(node, 1 + left.Item2 + right.Item2);
        }
    }
}