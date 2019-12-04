namespace IncreasingTripletSubsequence
{
    public class Solution
    {
        public bool IncreasingTriplet(int[] nums)
        {
            if (nums == null)
            {
                return false;
            }

            var min = int.MaxValue;
            var secondMin = int.MaxValue;
            foreach (var num in nums)
            {
                if (secondMin > min && num > secondMin)
                {
                    return true;
                }

                if (num < min)
                {
                    min = num;
                }

                if (num > min && num < secondMin)
                {
                    secondMin = num;
                }
            }

            return false;
        }
    }
}