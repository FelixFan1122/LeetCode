namespace LeetCode.ProductOfArrayExceptSelf
{
    public class Solution {
        public int[] ProductExceptSelf(int[] nums) {
            var products = new int[nums.Length];
            products[nums.Length - 1] = nums[nums.Length - 1];
            for (var i = nums.Length - 2; i > 0; i--)
            {
                products[i] = nums[i] * products[i + 1];
            }

            var leftProduct = 1;
            for (var i = 0; i < products.Length - 1; i++)
            {
                products[i] = leftProduct * products[i + 1];
                leftProduct *= nums[i];
            }

            products[products.Length - 1] = leftProduct;

            return products;
        }
    }
}