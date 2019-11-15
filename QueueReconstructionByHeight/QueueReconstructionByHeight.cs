using System;
using System.Collections.Generic;

namespace QueueReconstructionByHeight
{
    public class Solution
    {
        public int[][] ReconstructQueue(int[][] people)
        {
            Array.Sort(people, (x, y) => x[0] == y[0] ? x[1] - y[1] : y[0] - x[0]);
            var queue = new List<int[]>(people.Length);
            for (var i = 0; i < people.Length; i++)
            {
                queue.Insert(people[i][1], people[i]);
            }

            return queue.ToArray();
        }
    }
}