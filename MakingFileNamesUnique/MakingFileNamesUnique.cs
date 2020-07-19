using System.Collections.Generic;

namespace LeetCode.MakingFileNamesUnique
{
    public class Solution
    {
        public string[] GetFolderNames(string[] names)
        {
            var existing = new Dictionary<string, int>();
            var folders = new string[names.Length];
            for (var i = 0; i < names.Length; i++)
            {
                if (existing.ContainsKey(names[i]))
                {
                    while (existing.ContainsKey($"{names[i]}({existing[names[i]]})"))
                    {
                        existing[names[i]] += 1;
                    }

                    existing.Add($"{names[i]}({existing[names[i]]})", 1);
                    folders[i] = $"{names[i]}({existing[names[i]]})";
                }
                else
                {
                    existing.Add(names[i], 1);
                    folders[i] = names[i];
                }
            }

            return folders;
        }
    }
}