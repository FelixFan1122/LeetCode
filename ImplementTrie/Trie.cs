using System.Linq;

namespace LeetCode.ImplementTrie
{
    public class Trie
    {
        private readonly IStringSymbolTable<bool> stringSt;
        public Trie() => stringSt = new Trie<bool>();
        public void Insert(string word) => stringSt.Put(word, true);
        public bool Search(string word) => stringSt.Get(word);
        public bool StartsWith(string prefix) => stringSt.GetKeysOfPrefix(prefix).Any();
    }
}