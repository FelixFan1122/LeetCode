namespace HappyNumber
{
    public class Solution
    {
        public bool IsHappy(int n)
        {
            var hare = Next(Next(n));
            var tortoise = Next(n);
            while (hare != 1 && hare != tortoise)
            {
                hare = Next(Next(hare));
                tortoise = Next(tortoise);
            }

            return hare == 1;
        }

        private int Next(int n)
        {
            var next = 0;
            while (n > 0)
            {
                next += (n % 10) * (n % 10);
                n /= 10;
            }

            return next;
        }
    }
}