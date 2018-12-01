using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeSolutions
{
    public static class Arrays
    {

        public static void MoveZeroes(int[] nums)
        {
            int index = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    nums[index] = nums[i];
                    index++;
                }
            }

            for (; index < nums.Length; index++)
            {
                nums[index] = 0;
            }
        }
        public static int[] PlusOne(int[] digits)
        {
            if (digits[digits.Length - 1] != 9)
            {
                int digit = digits[digits.Length - 1];
                digit++;
                digits[digits.Length - 1] = digit;
                return digits;
            }

            digits[digits.Length - 1] = 0;
            int extra = 1;

            for (int i = digits.Length - 2; i >= 0; i--)
            {
                int digit = digits[i];
                if (digit != 9)
                {
                    digit += extra;
                    digits[i] = digit;
                    extra = 0;
                }
                else
                {
                    extra = 1;
                    digits[i] = 0;
                }
                if (extra == 0)
                    break; ;
            }

            if (extra == 1)
            {
                int[] biggerResult = new int[digits.Length + 1];

                biggerResult[0] = 1;
                for (int i = 1; i < biggerResult.Length; i++)
                {
                    biggerResult[i] = 0;
                }

                return biggerResult;
            }

            return digits;
        }
        public static int[] Intersect(int[] nums1, int[] nums2)
        {
            List<int> result = new List<int>();
            Dictionary<int, int> keys = new Dictionary<int, int>();
            foreach (var key in nums1)
            {
                if (keys.ContainsKey(key))
                {
                    keys[key]++;
                }
                else
                {
                    keys.Add(key, 1);
                }
            }

            foreach (var key in nums2)
            {
                if (keys.ContainsKey(key))
                {
                    if (keys[key] > 0)
                    {
                        result.Add(key);
                        keys[key]--;
                    }
                }
            }

            return result.ToArray();
        }
        public static int SingleNumber(int[] nums)
        {
            HashSet<int> keys = new HashSet<int>();

            foreach (var key in nums)
            {
                if (keys.Contains(key))
                {
                    keys.Remove(key);
                }
                else
                {
                    keys.Add(key);
                }
            }

            return keys.FirstOrDefault();
        }
        public static bool ContainsDuplicate(int[] nums)
        {
            HashSet<int> keys = new HashSet<int>();

            foreach (var key in nums)
            {
                if (keys.Contains(key))
                    return true;
                else
                {
                    keys.Add(key);
                }
            }

            return false;

        }
        public static int MaxProfit(int[] prices)
        {
            int profit = 0;
            if (prices.Length <= 1)
            {
                return 0;
            }

            int buyPrice = prices[0];
            int sellPrice = 0;

            for (int i = 1; i < prices.Length; i++)
            {
                int tempPrice = prices[i];

                if (sellPrice == 0)
                {
                    if (tempPrice <= buyPrice)
                    {
                        buyPrice = tempPrice;
                    }
                    else
                    {
                        sellPrice = tempPrice;
                    }
                }
                else if (tempPrice >= sellPrice)
                {
                    sellPrice = tempPrice;
                }
                else
                {
                    profit += sellPrice - buyPrice;
                    sellPrice = 0;
                    buyPrice = tempPrice;
                }
            }

            if (sellPrice != 0)
            {
                profit += sellPrice - buyPrice;
            }

            return profit;
        }
        public static void Rotate(int[] nums, int k)
        {
            if (nums.Length == 0)
                return;

            int index = 0;

            int temp = 0;
            int newIndex = 0;

            int temp2 = nums[0];

            HashSet<int> notVisitedIndex = new HashSet<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                notVisitedIndex.Add(i);
            }

            while (notVisitedIndex.Count > 0)
            {
                temp = temp2;
                newIndex = (index + k) % nums.Length;
                temp2 = nums[newIndex];
                nums[newIndex] = temp;

                notVisitedIndex.Remove(index);

                index = newIndex;

                if (!notVisitedIndex.Contains(index))
                {
                    index = notVisitedIndex.FirstOrDefault();
                    temp2 = nums[index];
                }
            }
        }
        public static int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 0;
            }

            int prev = nums[0];
            int length = 1;

            for (int i = 1; i < nums.Length; i++)
            {
                if (prev != nums[i])
                {
                    nums[length] = nums[i];
                    prev = nums[i];
                    length++;
                }
                else
                {
                    while (i < nums.Length && nums[i] == prev)
                    {
                        i++;
                    }

                    if (i >= nums.Length)
                    {
                        return length;
                    }

                    nums[length] = nums[i];
                    prev = nums[length];
                    length++;
                }
            }

            return length;
        }
    }
}
