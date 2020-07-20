using System;

namespace LeetCode.AverageSalaryExcludingTheMinimumAndMaximumSalary
{
    public class Solution
    {
        public double Average(int[] salary)
        {
            var min = 1000001;
            var max = 999;
            double sum = 0;
            foreach (var num in salary)
            {
                min = Math.Min(min, num);
                max = Math.Max(max, num);
                sum += num;
            }

            return (sum - min - max) / (salary.Length - 2);
        }
    }
}