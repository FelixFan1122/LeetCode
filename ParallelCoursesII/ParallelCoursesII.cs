using System;

namespace LeetCode.ParallelCoursesII
{
    public class Solution
    {
        public int MinNumberOfSemesters(int n, int[][] dependencies, int k)
        {
            var prerequisites = new int[n];
            for (var i = 0; i < dependencies.Length; i++)
            {
                prerequisites[dependencies[i][1] - 1] |= 1 << dependencies[i][0] - 1;
            }

            var isValid = new bool[1 << n]; // Is state i legal under the prerequisites constraint?
            for (var i = 0; i < 1 << n; i++)
            {
                var prerequisite = 0; // State i's prerequisite.
                for (var j = 0; j < n; j++)
                {
                    if ((i & 1 << j) > 0)
                    {
                        prerequisite |= prerequisites[j];
                    }
                }

                isValid[i] = (prerequisite & i) == prerequisite; // (j & i) == j means that i is a superset of j. A state is valid if all its prerequisite courses have been taken.
            }

            var mins = new int[1 << n]; // Min semesters for state i;
            Array.Fill(mins, n + 1);
            mins[0] = 0; // Base case;
            /*  Why can we build the DP array bottom-up?
                In another word we need to prove state i only depends on states that are less than i. So when we are at state i we know mins[i] will not change in the future and is ready to use.
                Because i | s will only add 1s to i, hence i | s is always greater than or equal to i. So we know we will always change values after current index not before, hence proving above.
            */
            for (var i = 0; i < mins.Length; i++)
            {
                if (!isValid[i]) continue;
                var candidates = 0;
                for (var j = 0; j < n; j++)
                {
                    if ((prerequisites[j] & i) == prerequisites[j])
                    {
                        candidates |= 1 << j;
                    }
                }

                candidates &= ~i; // Remove courses already taken.
                // Iterating all submasks of candidates. It's a common trick for iterating all submasks. Refer to https://cp-algorithms.com/algebra/all-submasks.html for detail.
                for (var s = candidates; s > 0; s = (s - 1) & candidates)
                {
                    if (CountBits(s) > k) continue;
                    mins[i | s] = Math.Min(mins[i | s], mins[i] + 1);
                }
            }

            return mins[mins.Length - 1];
        }

        private static int CountBits(int n)
        {
            var count = 0;
            while (n > 0)
            {
                count++;
                n &= n - 1;
            }
            
            return count;
        }
    }
}