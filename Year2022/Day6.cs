using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using Utilities;

namespace Year2022
{
    public static class Day6
    {
        private static readonly string Day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void All()
        {
            Part1();
            Part2();
        }

        public static void Part1()
        {
            string MethodName = MethodBase.GetCurrentMethod().Name;
            List<string> inputs = IO.ReadInputAsLines(Day);
            int result = 0;

            int strLength = 4;
            result = FindStartOfMessage(inputs[0], strLength);

            Console.WriteLine($"{Day} {MethodName} answer: {result}");
        }

        public static void Part2()
        {
            string MethodName = MethodBase.GetCurrentMethod().Name;
            List<string> inputs = IO.ReadInputAsLines(Day);
            int result = 0;

            int strLength = 14;
            result = FindStartOfMessage(inputs[0], strLength);

            Console.WriteLine($"{Day} {MethodName} answer: {result}");
        }

        private static bool ContainsDuplicates(string s)
        {
            List<char> chars = new();
            for (int i = 0; i < s.Length; i++)
            {
                if (chars.Contains(s[i]))
                    return true;
                chars.Add(s[i]);
            }
            return false;
        }

        private static int FindStartOfMessage(string input, int strLength)
        {
            for (int i = 0; i < input.Length; i++)
            {
                string s = input[i..(i + strLength)].ToString();
                if (!ContainsDuplicates(s))
                {
                    return i + strLength;
                }
            }
            return -1;
        }
    }
}
