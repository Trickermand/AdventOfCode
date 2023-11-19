using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Utilities;
using Year2020.Day4Helper;

namespace Year2020
{
    public static class Day4
    {
        private static readonly string Day = MethodBase.GetCurrentMethod().DeclaringType.Name;
        private static List<string> required = new() { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };

        public static void All()
        {
            Part1();
            Part2();
        }

        public static void Part1()
        {
            string inputs = IO.ReadAllText(Day);
            int result = 0;

            List<string> passport = inputs.Split("\n\n").ToList();

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
            string inputs = IO.ReadAllText(Day);
            int result = 0;

            List<string> passports = inputs.Split("\n\n").ToList();

            foreach (var passport in passports)
            {
                Passport p = new(passport);
                if (p.IsValid())
                    result++;
            }

            Console.WriteLine($"{Day} {MethodBase.GetCurrentMethod().Name} answer: {result}");
        }
    }
}
