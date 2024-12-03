using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using Utilities;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Year2024
{
    public static class Day3
    {
        private static readonly string Day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void All()
        {
            Part1();
            Part2();
        }

        public static void Part1()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            string MethodName = MethodBase.GetCurrentMethod().Name;
            string inputs = IO.ReadAllText(Day);
            int result = 0;

            var matches = Regex.Matches(inputs, "mul\\((\\d{1,3}),(\\d{1,3})\\)");

            foreach (Match match in matches)
            {
                int a = int.Parse(match.Groups[1].Value);
                int b = int.Parse(match.Groups[2].Value);
                result += a * b;
            }

            stopwatch.Stop();
            Console.WriteLine($"{Day} {MethodName} answer: {result} - in {stopwatch.ElapsedMilliseconds} ms");
        }

        public static void Part2()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            string MethodName = MethodBase.GetCurrentMethod().Name;
            string inputs = IO.ReadAllText(Day);
            int result = 0;

            var matches = Regex.Matches(inputs, "(don't\\(\\)|do\\(\\))|mul\\((\\d{1,3}),(\\d{1,3})\\)");

            bool isLastConditionMatchDo = true;
            foreach (Match match in matches)
            {
                if (match.Value.Equals("don't()"))
                {
                    isLastConditionMatchDo = false;
                    continue;
                }
                else if (match.Value.Equals("do()"))
                {
                    isLastConditionMatchDo = true;
                    continue;
                }

                if (isLastConditionMatchDo)
                {
                    int a = int.Parse(match.Groups[2].Value);
                    int b = int.Parse(match.Groups[3].Value);
                    
                    result += a * b;
                }
            }

            stopwatch.Stop();
            Console.WriteLine($"{Day} {MethodName} answer: {result} - in {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}
