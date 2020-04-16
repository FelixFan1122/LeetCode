using System.Collections.Generic;

namespace LeetCode.FizzBuzz
{
    public class Solution
    {
        public IList<string> FizzBuzz(int n)
        {
            var fizzBuzzs = new List<string>(n);
            for (var i = 1; i <= n; i++)
            {
                if (i % 3 == 0)
                {
                    if (i % 5 == 0)
                    {
                        fizzBuzzs.Add("FizzBuzz");
                    }
                    else
                    {
                        fizzBuzzs.Add("Fizz");
                    }
                }
                else if (i % 5 == 0)
                {
                    fizzBuzzs.Add("Buzz");
                }
                else
                {
                    fizzBuzzs.Add(i.ToString());
                }
            }

            return fizzBuzzs;
        }
    }
}