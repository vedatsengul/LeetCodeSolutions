using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeSolutions
{
    public static class Strings
    {
        public static bool IsPalindrome(string s)
        {
            StringBuilder build=new StringBuilder();
            
            foreach (var myChar in s)
            {
                if (char.IsLetterOrDigit(myChar))
                {
                    build.Append(myChar.ToString().ToLower());
                }
            }

            s = build.ToString();

            for (int i = 0, j = s.Length - 1; i < j; i++, j--)
            {
                if (s[i] != s[j])
                    return false;
            }

            return true;
        }

        public static bool IsAnagram(string s, string t)
        {
            Dictionary<char, int> chars=new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (chars.ContainsKey(s[i]))
                {
                    chars[s[i]]++;
                }
                else
                {
                    chars.Add(s[i],1);
                }
            }

            foreach (var c in t)
            {
                if (!chars.ContainsKey(c))
                    return false;
                if (chars[c] == 0)
                    return false;
                chars[c]--;
            }

            foreach (var pair in chars)
            {
                if (pair.Value != 0)
                    return false;
            }

            return true;
        }

        public static int FirstUniqChar(string s)
        {
            Dictionary<char, int[,]> chars = new Dictionary<char, int[,]>();
            int index = -1;
            for (int i = 0; i < s.Length; i++)
            {
                char temp = s[i];
                if (chars.ContainsKey(temp))
                {
                    chars[temp][0, 1]++;
                }
                else
                {
                    int[,] myArray = new int[1, 2]
                    {
                        {i,1}
                    };
                    chars.Add(temp, myArray);
                }
            }

            foreach (var c in chars)
            {
                if (c.Value[0, 1] == 1)
                {
                    if (index == -1 || index > c.Value[0, 0])
                    {
                        index = c.Value[0, 0];
                    }
                }
            }

            return index;
        }

        public static int Reverse(int x)
        {
            int result = 0;

            while (x != 0)
            {
                int rest = x % 10;

                if (x > 0)
                {
                    if (result > ((Int32.MaxValue - rest) / 10))
                    {
                        return 0;
                    }
                }
                else
                {
                    if (result < ((Int32.MinValue - rest) / 10))
                    {
                        return 0;
                    }
                }

                result = result * 10 + rest;
                x /= 10;
            }

            return result;
        }

        public static string ReverseString(string s)
        {
            StringBuilder newString = new StringBuilder();

            for (int i = s.Length - 1; i >= 0; i--)
            {
                newString.Append(s[i]);
            }

            return newString.ToString();
        }
    }
}
