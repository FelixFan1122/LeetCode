using System.Collections.Generic;

namespace LeetCode
{
    public interface IStringSymbolTable<T>
    {
        IEnumerable<string> Keys { get; }
        bool IsEmpty { get; }
        int Size { get; }

        bool Contains(string key);
        void Delete(string key);
        T Get(string key);
        IEnumerable<string> GetKeysOfPrefix(string prefix);
        IEnumerable<string> GetKeysThatMatch(string pattern);
        string GetLongestPrefixOf(string word);
        void Put(string key, T val);
    }
}