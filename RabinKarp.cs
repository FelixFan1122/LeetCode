using System;

namespace LeetCode
{
    public class RabinKarp
    {
        private readonly int alphabet;
        private readonly long coefficient;
        private readonly string pattern;
        private readonly long patternHash;
        private readonly long prime;

        public RabinKarp(string pattern, int alphabet, long prime)
        {
            if (pattern == null || pattern.Length == 0)
            {
                throw new ArgumentException(nameof(pattern));
            }

            if (alphabet <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(alphabet));
            }

            this.alphabet = alphabet;
            coefficient = (long)(prime - Math.Pow(alphabet, pattern.Length - 1) % prime);
            this.pattern = pattern;
            this.prime = prime;

            patternHash = 0;
            foreach (var character in pattern)
            {
                patternHash = (patternHash * alphabet + character) % prime;
            }
        }

        public int Search(string text)
        {
            if (text == null || text.Length < pattern.Length)
            {
                return -1;
            }

            long hash = 0;
            var i = 0;
            while (i < pattern.Length)
            {
                hash = (hash * alphabet + text[i++]) % prime;
            }

            while (hash != patternHash && i < text.Length)
            {
                hash = ((hash + text[i - pattern.Length] * coefficient) * alphabet + text[i]) % prime;
                i++;
            }

            return hash == patternHash ? i - pattern.Length : -1;
        }
    }
}