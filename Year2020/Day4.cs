using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using Utilities;

namespace Year2020
{
    public static class Day4
    {
        private static readonly string Day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void All()
        {
            Part1();
            Part2();
        }

        public static void Part1()
        {
            string inputs = IO.ReadAllText(Day);
            int result = 0;

            List<string> passport = inputs.Split("\r\n\r\n").ToList();
            List<string> required = new List<string>() { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };

            for (int i = 0; i < passport.Count; i++)
            {
                if (ContainsAllItems(passport[i], required))
                    result++;
            }

            Console.WriteLine($"{Day} {MethodBase.GetCurrentMethod().Name} answer: {result}");
        }

        private static bool ContainsAllItems(string input, List<string> keys)
        {
            return keys.All(x => input.Contains(x));
        }

        public static void Part2()
        {
            List<string> inputs = IO.ReadInputAsLines(MethodBase.GetCurrentMethod().DeclaringType.Name);
            int result = 0;



            Console.WriteLine($"{Day} {MethodBase.GetCurrentMethod().Name} answer: {result}");
        }
    }
}
