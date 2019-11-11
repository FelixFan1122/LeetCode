using System.Collections.Generic;

namespace DailyTemperatures
{
    public class Solution {
        public int[] DailyTemperatures(int[] T) {
            if (T == null)
            {
                return new int[0];
            }
            
            var warmerDays = new Stack<int>();
            var nextWarmerDay = new int[T.Length];
            for (var i = T.Length - 1; i >= 0; i--)
            {
                while (warmerDays.Count > 0 && T[i] >= T[warmerDays.Peek()])
                {
                    warmerDays.Pop();
                }
                
                nextWarmerDay[i] = warmerDays.Count == 0 ? 0 : warmerDays.Peek() - i;
                warmerDays.Push(i);
            }
            
            return nextWarmerDay;
        }
    }   
}